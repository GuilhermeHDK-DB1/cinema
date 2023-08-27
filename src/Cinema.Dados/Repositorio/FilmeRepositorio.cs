﻿using Cinema.Dados.Contextos;
using Cinema.Dominio.Common;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Dados.Repositorio
{
    public class FilmeRepositorio : RepositorioBase<Filme>, IFilmeRepositorio
    {
        private readonly ApplicationDbContext _context;

        public FilmeRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override Filme ObterPorId(int id)
        {
            var query = _context.Set<Filme>()
                .Where(entidade => entidade.Id == id)
                .Include(entidade => entidade.Genero);
            return query.Any() ? query.First() : null;
        }

        public override List<Filme> ObterTodos()
        {
            var entidades = _context.Set<Filme>()
                .Include(entidade => entidade.Genero)
                .ToList();
            return entidades.Any() ? entidades : new List<Filme>();
        }

        public override List<Filme> ObterPaginado(int skip, int take)
        {
            var entidades = _context.Set<Filme>()
                .Include(entidade => entidade.Genero)
                .Skip(skip)
                .Take(take)
                .ToList();
            return entidades.Any() ? entidades : new List<Filme>();
        }

        public IEnumerable<Filme> ObterPorGenero(string genero)
        {
            var entidades = _context.Set<Filme>()
                .Include(entidade => entidade.Genero)
                .Where(entidade => entidade.Genero.Nome.Contains(genero))
                .ToList();
            return entidades.Any() ? entidades : new List<Filme>();
        }

            public Filme ObterPeloNome(string nome)
        {
            var filme = _context.Set<Filme>().Where(filme => filme.Nome.Contains(nome));
            return filme.Any() ? filme.First() : null;
        }
    }
}
