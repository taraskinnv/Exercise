using System.ServiceModel;


namespace WinFormsAppClient
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        int NumberLines(string s);  // функция вычисления  слов в предложении
        [OperationContract]
        int NumberGlas(string s);   // функция поиска анг. гласных букв
    }
}

