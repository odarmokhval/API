using IShop.BusinessLogic.Services;
using IShop.Domain.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IShop.Controllers
{
    public class ProductsController : ApiController
    {
        IProductService _productService
            = new ProductService();

        [OverrideAuthentication]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody] Product product)
        {
            if(!ModelState.IsReadOnly)
            {
                var errorMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                errorMessage.Content = new StringContent("Name can't be empty");

                return errorMessage;
            }
            
            _productService.Add(product);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
