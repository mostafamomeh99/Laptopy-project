using Microsoft.AspNetCore.Identity;
using Repositorypattern.core.IDatabaseRepository;
using Repositorypattern.core.Models;
using Repositorypattern.core.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ef.Repositories
{
    public class UnitOFWork : IUnitOFWork
    {
        private readonly ApplicationDbContext context;

        public IProductRepository Products { get; private set; }
        public IDatabaseRepository<ProductSpeciality> ProductSpecials { get; private set; }
 
        public UnitOFWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager ,
            SignInManager<ApplicationUser> singInManager
            )
        {
            this.context = context;
            Products = new ProductRepository(context);
            ProductSpecials = new DatabaseRepository<ProductSpeciality>(context);
  
        }

        public int Compelet()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
