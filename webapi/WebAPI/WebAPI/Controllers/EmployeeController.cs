using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName); // Cria o caminho, ex: Storage\\scraps.png (compatível com Windows/Linux)
            using Stream fileStream = new FileStream(filePath, FileMode.Create); // cria o arquivo físico vazio, com o nome do filepath
            employeeView.Photo.CopyTo(fileStream);                               // Copia o arquivo de fato para o arquivo vazio criado na linha de cima

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath); // colocar somente o caminho no banco
            employeeRepository.Add(employee);
            return Ok(); // codigo 200 - ok
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = employeeRepository.Get();
            return Ok(employees); // codigo 200 - ok
        }

        [HttpGet]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo); // transforma o arquivo em byte pra ser retornado

            return File(dataBytes, "image/png");
        }
    }
}
 