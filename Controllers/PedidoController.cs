using Microsoft.AspNetCore.Mvc;

namespace APIPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            return Ok(Carrinho.Listar());
        }

        [HttpPost("Inserir")]

        public IActionResult Inserir(Produto produto)
        {
            Carrinho.Inserir(produto);
            return new ObjectResult(produto) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                var produtos = Carrinho.Alterar(produto);
                return NoContent(); //Sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("Excluir")]
        public IActionResult Excluir([FromBody] int id)
        {
            try
            {
                Carrinho.Excluir(id);
                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

    

    
}