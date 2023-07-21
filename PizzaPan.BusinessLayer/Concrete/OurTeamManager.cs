using PizzaPan.BusinessLayer.Abstract;
using PizzaPan.DataAccessLayer.Abstract;
using PizzaPan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.BusinessLayer.Concrete
{
    public class OurTeamManager : IOurTeamService
    {
        private readonly IOurTeamDAL ourTeamDAL;

        public OurTeamManager(IOurTeamDAL ourTeamDAL)
        {
            this.ourTeamDAL = ourTeamDAL;
        }
        public void TDelete(OurTeam t)
        {
            ourTeamDAL.Delete(t);
        }

        public OurTeam TGetByID(int id)
        {
            return ourTeamDAL.GetByID(id);
        }

        public List<OurTeam> TGetList()
        {
            return ourTeamDAL.GetList();
        }

        public void TInsert(OurTeam t)
        {
            ourTeamDAL.Insert(t);
        }

        public void TUpdate(OurTeam t)
        {
            ourTeamDAL.Update(t);
        }
    }
}
