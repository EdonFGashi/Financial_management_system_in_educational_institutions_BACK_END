using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Helpers
{
    //kjo klase do te perdoret per te krijuar nje header te ri ne http response
    //e bejme statike sepse nuk do te krijojme instanca te kesaj klase
    public static class HttpContextExtensions
    {
        public async static Task InsertParameterPaginationHeader<T>(this HttpContext httpContext, //httpContext eshte konteksti i kerkeses
            IQueryable<T> queryable)
        {
            if (httpContext == null)//nese httpContext eshte null, atehere do te bejme throw
            {
                throw new ArgumentNullException(nameof(httpContext));//e bejme throw me emrin e variablit
            }

            //numrin total te rekordeve e ruajme ne kete variabel
            double count = await queryable.CountAsync(); //kemi nevoje per numrin e rekordeve qe do te kthehen, dhe e bejme async
            //e vendosim ne headerin e responses numrin total te rekordeve, ne kete menyre klienti do ta dije numrin total te rekordeve
            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());

            //kete  metode do ta therrasim tek GenresController
        }
    }
}
