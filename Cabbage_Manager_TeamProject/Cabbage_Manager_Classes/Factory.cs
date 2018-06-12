using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class Factory
    {
        private static Factory _instance;

        public static Factory Instance => _instance ?? (_instance = new Factory());

        private DbRepository _repo;

        public DbRepository GetRepository() => _repo ?? (_repo = new DbRepository());

        private UI_Logic _ui_logic;

        public UI_Logic GetUiLogic() => _ui_logic ?? (_ui_logic = new UI_Logic());
    }
}
