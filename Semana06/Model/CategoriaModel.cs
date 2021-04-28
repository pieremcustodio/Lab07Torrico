using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Entity;

namespace Semana06.Model
{
    public class CategoriaModel
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public bool Insertar(Categoria categoria)
        {
            return (new BCategoria()).Insertar(categoria);
        }
        public bool Actualizar(Categoria categoria)
        {
            return (new BCategoria()).Actualizar(categoria);
        }

        public CategoriaModel()
        {
            var lista = (new BCategoria().List(0));
            Categorias = new ObservableCollection<Categoria>(lista);
        }
    }
}
