using System.Collections.Generic;

namespace Dio.projUm.Interfaces
{
    public interface IRepositorio<T>
    {

        //https://docs.microsoft.com/pt-br/dotnet/api/system.collections.generic.list-1?view=net-5.0
         List<T> Lista();

         T RetornaPorId(int id);    

         void Insere(T entidade);

         void Exclui(int id);

         void Atualiza(int id,T entidade);
         
         int ProximoId();
    }
}