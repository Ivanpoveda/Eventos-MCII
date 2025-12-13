using Microsoft.EntityFrameworkCore;
using BDEVENTOS.Models;

namespace BDEVENTOS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SolicitudSoporte> SolicitudesSoporte { get; set; }
        public DbSet<Participante> Participantes { get; set; }
    }
}
