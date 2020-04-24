using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Logics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public HostingController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            var players = _repository.Player.GetAllPlayers();
            var result = _mapper.Map<IEnumerable<PlayerDto>>(players);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateHost([FromBody]PlayerForUpdateDto player)
        {
            try
            {
                if (player == null)
                {
                    _logger.LogError("Player object sent from client is null.");
                    return BadRequest("Player object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Player object sent from client.");
                    return BadRequest("Invalid model object");
                }

                SessionCodeGenerator generator = new SessionCodeGenerator();
                TopicCreator creator = new TopicCreator();

                // create new session

                // start create new session code
                string session_code = "";
                bool inUse = true;
                while (inUse)
                {
                    session_code = generator.GenerateSessionCode();

                    inUse = _repository.SessionData.ValidateIfActive(session_code);
                }
                // end create new session code

                // start create new session
                SessionData sessionData = new SessionData();
                sessionData.session_code = session_code;

                _repository.SessionData.CreateSession(sessionData);
                // end create new session

                // start create new topic
                TopicData data = creator.CreateNewTopic();
                data.sessionCode = session_code;

                _repository.TopicData.CreateTopic(data);
                _repository.Save();
                // end create new topic

                // start create new player
                Player PlayerEntity = _mapper.Map<Player>(player);
                PlayerEntity.orderNumber = 1;
                PlayerEntity.session_id = sessionData.id;

                _repository.Player.CreatePlayer(PlayerEntity);
                _repository.Save();

                // end create new player

                var session = _repository.SessionData.GetBySessionCodeWithDetails(session_code);
                SessionDataDto result = _mapper.Map<SessionDataDto>(session);

                return Ok(result);
                //return CreatedAtRoute("CategoryById", new { id = createdEntity.id }, createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateArtist action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("JoinGame")]
        [HttpPost("session_Code")]
        public IActionResult JoinHost(string session_Code, [FromBody]PlayerForUpdateDto player)
        {
            if (player == null)
            {
                _logger.LogError("Player object sent from client is null.");
                return BadRequest("Player object is null");
            }

            if (session_Code == null)
            {
                _logger.LogError("Session code sent by client is null.");
                return BadRequest("Session code is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Player object sent from client.");
                return BadRequest("Invalid model object");
            }

            SessionData sessionData = _repository.SessionData.GetBySessionCodeWithDetails(session_Code);

            if (sessionData.players.Count() >= 4)
            {
                return Ok("session full");
            }

            // start create new player
            Player PlayerEntity = _mapper.Map<Player>(player);
            PlayerEntity.orderNumber = sessionData.players.Count() + 1;
            PlayerEntity.session_id = sessionData.id;

            _repository.Player.CreatePlayer(PlayerEntity);
            _repository.Save();

            var session = _repository.SessionData.GetBySessionCodeWithDetails(session_Code);
            SessionDataDto result = _mapper.Map<SessionDataDto>(session);

            return Ok(result);
        }
    }
}