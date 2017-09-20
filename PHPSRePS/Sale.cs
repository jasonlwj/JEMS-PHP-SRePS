﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPSRePS {
   public class Sale : HasSQLTable {
       private const string _SQLTable = "sales";
       private const string _SQLcols = _SQLTable + "(SalesID,SalesDate,EmployeeID)";

       private int _id;
       private string _date;
       private string _employee;

        public int Id { get => _id; set => _id = value; }
        public string Date { get => _date; set => _date = value; }
        public string Employee { get => _employee; set => _employee = value; }

        // constructor to init data
        public Sale(int id, string date, string employee)
        {
            this.Id = id;
            this.Date = date;
            this.Employee = employee;
        }

        // empty constructor
        public Sale()
        {

        }

        //gets coulombs used by the mySQL table
        private string GetSQLValues()
        {
            return Id.ToString() + "," + Date + "," + Employee;
        }

        //returns a mySQL INSERT statement
        override public string GetINSERT()
        {
            return base.GetINSERT(_SQLcols, GetSQLValues());
        }

        //returns a mySQL DELETE statement
        override public string GetDELETE()
        {
            return base.GetDELETE(_SQLTable, Id.ToString());
        }

        //returns a mySQL UPDATE statement
        //public override string GetUPDATE(string updateName, string updateValue)
        //{
        //    return base.GetUPDATE(_SQLTable, updateName, updateValue, "SalesID", Id.ToString());
        //}

        public override string GetUPDATE()
        {
            return
                "UPDATE product" +
                "SET SalesDate = '" + Date + "'," +
                "EmployeeID = '" + 0 + "'," +
                "WHERE SalesID = " + Id;
        }
    }
}
