﻿using Dominio.Core.Interfaces.Notificacao;
using Dominio.Principal.Notificacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class Desenvolvedor : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        
        public Desenvolvedor()
        {
            SetNotificacao(new NotificacaoDominio());            
        }
                
        public bool Validar(bool IsRemovendo)
        {
            if (!IsRemovendo)
            {
                if (String.IsNullOrWhiteSpace(Nome))
                    NotificacaoDominio.AddErro("Nome do desenvolvedor deve ser informado.");
                else if(Nome.Length <= 2)
                    NotificacaoDominio.AddErro("Nome do desenvolvedor deve ter no mínimo 2 caracteres.");
            }

            return NotificacaoDominio.ErroMensagens.Count() == 0;
        }
    }
}
