using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTasks.API.DTOs;
using MyTasks.Domain.VO;
using MyTasks.Infra;
using Serilog;

namespace MyTasks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyTasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMyTasksRepository _myTasksRepository;

        public MyTasksController(IMapper mapper, IMyTasksRepository myTasksRepository)
        {
            _mapper = mapper;
            _myTasksRepository = myTasksRepository;
        }

        private readonly ILogger<MyTasksController> _logger;

        [HttpGet]
        [Route("/Health")]
        public ActionResult<String> Health()
        {
            return Ok("Live!!");
        }

        [HttpGet]
        [Route("/MyTasks/GetAllTasks")]
        public ActionResult<IEnumerable<MyTaskDTO>> Get()
        {
            try
            {
                Log.Information("Iniciando o processamento da requisição");
                var myTasks = _myTasksRepository.GetAllMyTasks();
                return Ok(_mapper.Map<IEnumerable<MyTaskDTO>>(myTasks));
            }
            catch (Exception e)
            {
                Log.Error("Error on GetAllTasks. Ex:" + e);
                throw;
            }
        }

        [HttpGet("/MyTasks/GetById/{id}")]
        public ActionResult<MyTaskDTO> GetById(long id)
        {
            try
            {
                return Ok(_myTasksRepository.GetById(id));
            }
            catch (Exception e)
            {
                Log.Error("Error on GetById. Ex:" + e);
                throw;
            }
        }

        [HttpPost("/MyTasks/Create")]
        public IActionResult Create(MyTaskDTO myTaskDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Log.Error("Error on Update's Request. Validation: " + ModelState);
                    return BadRequest(ModelState);
                }

                var myTask = _mapper.Map<MyTaskVO>(myTaskDTO);
                _myTasksRepository.CreateMyTask(myTask);

                return Ok();
            }
            catch (Exception e)
            {
                Log.Error("Error on Create. Ex:" + e);
                throw;
            }
        }

        [HttpDelete("/MyTasks/Delete/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _myTasksRepository.DeleteMyTask(id);
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error("Error on Delete. Ex:" + e);
                throw;
            }
        }

        [HttpPut("/MyTasks/Update")]
        public ActionResult<MyTaskDTO> Update(MyTaskDTO myTaskDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Log.Error("Error on Update's Request. Validation: " + ModelState);
                    return BadRequest(ModelState);
                }

                return Ok(_myTasksRepository.UpdateMyTask(_mapper.Map<MyTaskVO>(myTaskDTO)));
            }
            catch (Exception e)
            {
                Log.Error("Error on Update. Ex:" + e);
                throw;
            }
        }

        [HttpPut("/MyTasks/MarkAsDone/{id}")]
        public ActionResult<MyTaskDTO> MarkAsDone(long id, Boolean isDone)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Log.Error("Error on Update's Request. Validation: " + ModelState);
                    return BadRequest(ModelState);
                }

                return Ok(_myTasksRepository.MarkAsDone(id, isDone));

            }
            catch (Exception e)
            {
                Log.Error("Error on Update. Ex:" + e);
                throw;
            }
        }
    }
}
