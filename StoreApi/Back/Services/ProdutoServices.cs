﻿using Back.Models;
using Back.Services.Interfaces;
using Back.ViewModel;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Back.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private Context _context;

        public ProdutoServices(Context context)
        {
            _context = context;
        }

        public Produto Create(ProdutoViewModel prod)
        {
            if (prod == null) return null;
            Produto produto = new Produto();
            produto.Id = produto.Id;
            produto.Nome = prod.Nome;
            produto.Descricao = prod.Descricao;
            produto.CategoriaId = prod.CategoriaId;
            produto.Imagem = prod.Imagem;
            produto.Valor = prod.Valor;
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto Create(Produto u)
        {
            throw new System.NotImplementedException();
        }

        public Produto Delete(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Remove(produto);
                _context.SaveChanges();
                return produto;
            }
            return new Produto();
        }

        public Produto Edit(int id, Produto New)
        {
            Produto produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                produto.Nome = New.Nome;
                produto.Descricao = New.Descricao;
                produto.Imagem= New.Imagem;
                produto.Valor = New.Valor;
                _context.SaveChanges();
                return produto;
            }
            return null;
        }

        public List<Produto> Get()
        {
            List<Produto> produto = _context.Produto
                .Select(x => new Produto
                {
                    Id = x.Id,
                    Categoria = x.Categoria,
                    CategoriaId = x.CategoriaId,
                    Nome = x.Nome,
                    Descricao = x.Descricao,
                    Valor = x.Valor,    
                    Imagem = x.Imagem
                }).ToList();
            return produto;
        }

        public Produto GetForId(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(p => p.Id == id);
            if (produto == null) return null;
            return produto;
        }

        bool IBaseServices<Produto>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
