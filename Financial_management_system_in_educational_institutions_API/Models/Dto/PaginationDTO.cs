namespace MovieAPI.DTOs
{
    public class PaginationDTO
    {
        //kjo eshte per paginimin e te dhenave, dmth sa rekorde do te shfaqen ne nje faqe dhe ne cilen faqe do te shfaqen
        //kjo eshte nje klase e perbashket per te gjitha entitetet qe do te perdorin paginimin
        //nese nuk vendosim ndonje vlere, do te perdoren vlerat default
        //Vlerat e anetareve te kesaj klase do te caktohen ne query string qe vjen nga front endi
        //p.sh: /api/genres?page=2&recordsPerPage=10
        //parametri per querystring vendoset tek metoda Get() ne controller me annotation [FromQuery]
        public int Page { get; set; } = 1;

        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage;
            }
            set
            {//nese numri i rekordeve ne nje faqe kerkohet qe te jete me i madh se maksimumi, atehere do te vendoset vlera e maksimumit
                recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
            }
        }
    }
}
