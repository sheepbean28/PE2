using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE2.Model
{
    public partial class InFixture : OutFixture
    {
        public void InChangeFixture(Fixture model)
        {
            Fixture = model;
            //Create_date = Convert.ToInt32(model.Create_date);
            Fixture_sn = model.Fixture_sn;
            Fixture_no = model.Fixture_no;
            Fixture_car = model.Fixture_car;
            Fixture_car1 = model.Fixture_car1;
            Fixture_car2 = model.Fixture_car2;
            Fixture_name = model.Fixture_name;
            Fixture_usefor = model.Fixture_usefor;
            Fixture_no_old = model.Fixture_no_old;
            Fixture_lic_old = model.Fixture_lic_old;
            Fixture_sn_old = model.Fixture_sn_old;
            Status = model.Status;
            Quantity = model.Quantity;
            Limit_date = model.Limit_date;
            FixtureNote = model.Note;
        }
    }
}
