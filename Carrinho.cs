namespace APIPedidos
{

    public class Produto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }


    public class Carrinho
    {
        private static List<Produto> Produtos = new List<Produto>()
        {
            new Produto{ Id = 1, Description = "Teste"},
            new Produto{ Id = 2, Description = "Teste2"},
            new Produto{ Id = 3, Description = "Teste3"}
        };

        public static List<Produto> Listar()
        {
            return Produtos;
        }

        public static Produto Inserir(Produto produto)
        {
            Produtos.Add(produto);
            return produto;
        }

        public static Produto Alterar(Produto produto)
        {
            var index = Produtos.FindIndex(p => p.Id == produto.Id);

            return produto;

            if (index == -1)
                throw new Exception("Não encontrado");

            Produtos[index] = produto;
        }

        public static void Excluir(int id)
        {
            var index = Produtos.FindIndex(p => p.Id == id);

            if (index == -1)
                throw new Exception($"Produto {id} não encontrado.");

            Produtos.RemoveAt(index);
        }
    }
}
