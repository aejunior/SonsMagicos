using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsMagicos.Dominio.Conta;

public interface IAutenticar
{
    Task<bool> Autenticar(string email, string senha);
}
