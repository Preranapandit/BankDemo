﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBank
{
    class CustomerBLL
    {
        //properties
        private string fname;
        private string lname;
        private char gender;
        private string Dob;
        private string Address;
        private string Phonenumber;
        private float Balance;
        private int accountNo;
        private int pinNo;


        public CustomerBLL()
        {

        }

        public CustomerBLL(string fname, string lname, char gender, string Dob, string Address, string Phonenumber, string Balance, int accountNo, int pinNo)
        {
            this.fname = fname;
            this.lname = lname;
            this.gender = gender;
            this.Dob = Dob;
            this.Address = Address;
            this.Phonenumber = Phonenumber;
            this.Balance = float.Parse(Balance);
            this.accountNo = accountNo;
            this.pinNo = pinNo;

        }


        //getter and setter for all labels
        public string _fname
        {
            get { return fname; }
            set { this.fname = value; }
        }
        public string _lname
        {
            get { return lname; }
            set { this.lname = value; }
        }
        public char _gender
        {
            get { return gender; }
            set { this.gender = value; }
        }
        public string _Dob
        {
            get { return Dob; }
            set { this.Dob = value; }
        }
        public string _Address
        {
            get { return Address; }
            set { this.Address = value; }
        }
        public string _Phonenumber
        {
            get { return Phonenumber; }
            set { this.Phonenumber = value; }
        }
        public float _Balance
        {
            get { return Balance; }
            set { this.Balance = value; }
        }
        public int _accountNo
        {
            get { return accountNo; }
            set { this.accountNo = value; }
        }
        public int _pinNo
        {
            get { return pinNo; }
            set { this.pinNo = value; }
        }


        //dbconnection
        DbConnection dbconnection = new DbConnection();
        
        
        //Account Number autogenerated after clicking on Create Account
            
            public int generateAccountNo()
        {
            string query;
            query = "select max(accountNo) from Customer";
            DataTable dt = dbconnection.Retrieve(query);
            if (dt.Rows[0][0].ToString()!="")
            {
                return int.Parse(dt.Rows[0][0].ToString()) + 1;
            }
            else
            {
                return 20100;
            }

        }

        //generetae random pin number for customers

        public int generatePin()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999);
        }


        //insert query from Customer table

        public void createAccount()
        {
            string query;
            query = "insert into Customer(fname,lname,gender,dob,address,phonenumber,balance,accountNo,pinNo)values('" + fname + "','" + lname + "','" + gender + "','" + Dob + "','" + Address + "','" + Phonenumber + "','" + Balance + "','" + accountNo + "','" + pinNo + "')";
            dbconnection.Manipulate(query);
        }


        public DataTable retrieveCustomer()
        {
            string query;
            query = "select customerid, fname, lname, gender, dob, address, phonenumber, balance, accountNo, pinNo from Customer;";

            DataTable dt = dbconnection.Retrieve(query);
            return dt;
        }


        public DataTable selectCustomer(int Customerid)
        {
            string query;
            query = "select fname, lname, gender, dob, address, phonenumber, balance, accountNo, pinNo from Customer where Customerid = " + Customerid;

            DataTable dt = dbconnection.Retrieve(query);
            return dt;
        }


        public void deleteCustomer(int Customerid)
        {
            string query;
            query = "delete from Customer where Customerid =" + Customerid;
            dbconnection.Manipulate(query);
        }

        //update
        public void updateCustomer(int Customerid)
        {
            string query;
            query = "Update Customer set fname='" + fname + "', lname='" + lname + "', gender = '"+gender+"',dob = '"+Dob+"', address='" + Address + "',phonenumber='" + Phonenumber + "',balance='" + Balance + "' where Customerid = " + Customerid;
            dbconnection.Manipulate(query);
        }





    }
}
