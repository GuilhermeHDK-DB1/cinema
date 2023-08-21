//using Cinema.Dominio.Common;
//using Cinema.Dominio.Dtos.Generos;
//using Cinema.Dominio.Entities.Generos;

//namespace Cinema.Dominio.Services.Handlers
//{
//    public class ManipuladorDeGenero
//    {
//        private readonly IGeneroRepositorio _generoRepositorio;

//        public ManipuladorDeGenero(IGeneroRepositorio generoRepositorio)
//        {
//            _generoRepositorio = generoRepositorio;
//        }

//        public GeneroReadDto Adicionar(GeneroCreateDto generoDto)
//        {
//            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

//            ValidadorDeRegra.Novo()
//                .Quando(generoJaSalvo != null, Resources.NomeDoGeneroJaExiste)
//                .DispararExcecaoSeExistir();

//            var genero = new Genero(generoDto.Nome);
//            _generoRepositorio.Adicionar(genero);

//            return new GeneroReadDto(genero);
//        }

//        public GeneroReadDto Atualizar(int id, GeneroUpdateDto generoDto)
//        {
//            var genero = _generoRepositorio.ObterPorId(id);
//            var generoJaSalvo = _generoRepositorio.ObterPeloNome(generoDto.Nome);

//            ValidadorDeRegra.Novo()
//                .Quando(generoJaSalvo != null && generoJaSalvo.Nome == genero.Nome && generoJaSalvo.Id != genero.Id
//                , Resources.NomeDoGeneroJaExiste)
//                .DispararExcecaoSeExistir();

//            if (!string.IsNullOrEmpty(generoDto.Nome)) genero.Nome = generoDto.Nome;

//            _generoRepositorio.Adicionar(genero);

//            return new GeneroReadDto(genero);
//        }

//        //public void Excluir(int id)
//        //{
//        //    var genero = _generoRepositorio.ObterPorId(id);

//        //    if (genero != null)
//        //        _generoRepositorio.Excluir(genero);
//        //}
//    }
//}