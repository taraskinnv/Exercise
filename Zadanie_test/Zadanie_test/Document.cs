namespace Zadanie_test
{
    public class Document
    {
        public string TMV { get; set; }  // товарно-материальные ценности
        //string nomination { get; set; }
        public string Date_of_issue { get; set; }  // Дата выдачи
        public string Valid_until { get; set; }    // Действительна до .... (Дата)
        public string Document_Number { get; set; }    // № документа
        public string Document_Date { get; set; }  // Дата документа
        public string Issued_to { get; set; }  //Кому выдан
        public string Type_of_identity_Doc { get; set; }   // Тип документа удостоверяющего личность (паспорт)
        public string Doc_series { get; set; }     // Серия документа
        public string Doc_Number { get; set; }      //Номер документа
        public string Date_his_issue { get; set; } // Дата его выдачи
        public string Issued_by { get; set; }      // Кем выдан
        public string Organization { get; set; }   //Организация
        public string Contract { get; set; }   //Договор
        public int Amount { get; set; }    // Кол-во ТВЦ

        public string Set_TMV(int number,string nomination, string unit, int amount)
            {
            return number + " " + nomination + " " + unit + " " + amount;
        }
        
        public Document(string tmv, string date_of_issue, string valid_until, string document_number, string document_date, string issued_to, string type_of_identity_Doc, string doc_series, string doc_Number, string date_his_issue, string issued_by, string organization, string contract, int amount)
        {
            TMV = tmv;
            Date_of_issue = date_of_issue;
            Valid_until = valid_until;
            Document_Number = document_number;
            Document_Date = document_date;
            Issued_to = issued_to;
            Type_of_identity_Doc = type_of_identity_Doc;
            Doc_series = doc_series;
            Doc_Number = doc_Number;
            Date_his_issue = date_his_issue;
            Issued_by = issued_by;
            Organization = organization;
            Contract = contract;
            Amount = amount;
        }

        public Document()
        {

        }
    }
}
