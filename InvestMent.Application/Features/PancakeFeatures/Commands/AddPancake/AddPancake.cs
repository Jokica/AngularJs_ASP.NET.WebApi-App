using InvestMent.DAL.DTOs;
using InvestMent.DAL.UnitOfWork;
using InvestMent.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace InvestMent.Application.Features.Pancakes.Commands
{
    public class AddPancakeRequest : IRequest
    {
        [Required]
        public string Name { get;  set; }
        public List<IngredientsDTO> Ingredients { get; set; } = new List<IngredientsDTO>();
        public long? BrandId { get; set; }
        public HttpPostedFile ImageFile { get; set; }
    }
    public class AddPancakeHandler : AsyncRequestHandler<AddPancakeRequest>
    {
        private IUnitOfWork unitOfWork;
        private IList<string> AllowedFileExtensions;
        private int MaxContentLength;
        public AddPancakeHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
            MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  
        }
        protected override Task Handle(AddPancakeRequest request, CancellationToken cancellationToken)
        {
            Brand brand = request.BrandId.HasValue ? unitOfWork.Brand.Find(request.BrandId.Value) : default(Brand);

            if (request.ImageFile !=null && request.ImageFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(request.ImageFile.FileName);
                if (!AllowedFileExtensions.Contains(extension) ||
                    request.ImageFile.ContentLength > MaxContentLength)
                {
                    return Task.FromResult(0);
                }
                var VirtualPath = Path.Combine("~/Images/", request.ImageFile.FileName + extension);
                var filePath = HttpContext.Current.Server.MapPath(VirtualPath);
                request.ImageFile.SaveAs(filePath);
                var Pancake = new Pancake(request.Name, brand, VirtualPath);
                foreach (var ingredientDto in request.Ingredients)
                {
                    Ingredient ingredient = unitOfWork.Ingridents.Find(ingredientDto.Id);
                    Pancake.AddIngredient(ingredient);
                }
                unitOfWork.Pancakes.Add(Pancake);
                return unitOfWork.CompleteAsync();
            }
          return Task.FromResult(0);
        }
    }
}
