using BDEVENTOS.Models;
using Eventos_MCII.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos_MCII.Data
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
