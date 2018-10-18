using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_test
{
    public class Document
    {
        string TMV { get; }  // товарно-материальные ценности
        //string nomination { get; set; }
        DateTimePicker Date_of_issue { get; set; }  // Дата выдачи
        DateTimePicker Valid_until { get; set; }    // Действительна до .... (Дата)
        public string Document_Number { get; set; }    // № документа
        string Document_Date { get; set; }  // Дата документа
        string issued_to { get; set; }  //Кому выдан
        string Type_of_identity_Doc { get; set; }   // Тип документа удостоверяющего личность (паспорт)
        string Doc_series { get; set; }     // Серия документа
        string Doc_Number { get; set; }      //Номер документа
        string Date_his_issue { get; set; } // Дата его выдачи
        string Issued_by { get; set; }      // Кем выдан
        string Organization { get; set; }   //Организация
        string Contract { get; set; }   //Договор
        int Amount { get; set; }    // Кол-во ТВЦ

        public string Set_TMV(int number,string nomination, string unit, int amount)
        {
            return number + " " + nomination + " " + unit + " " + amount;
        }

        //public Document(string TMV, DateTimePicker Date_of_issue, DateTimePicker Valid_until, )
        //{

        //}

        public Document()
        {

        }
    }
}
