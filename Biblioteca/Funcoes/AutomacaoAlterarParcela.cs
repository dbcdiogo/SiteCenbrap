using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Entidades;
using Biblioteca.DB;

namespace Biblioteca.Funcoes
{
    public class AutomacaoAlterarParcela
    {
        public static void Alterar()
        {
            List<Curso> c = new CursoDB().AutomacaoAlterarParcela(1);
            foreach(var a in c)
            {
                Curso curso = new CursoDB().Buscar(a.codigo);
                curso.pgto_1parcela = 1;
                curso.Alterar();
            }

            //List<Curso> c2 = new CursoDB().AutomacaoAlterarParcela(2);
            //foreach (var a in c2)
            //{
            //    Curso curso = new CursoDB().Buscar(a.codigo);
            //    curso.pgto_1parcela = 2;
            //    curso.Alterar();
            //}
        }

    }

}