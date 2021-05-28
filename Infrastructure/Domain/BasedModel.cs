using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Infrastructure.Domain

{
    public class BasedModel
    {
        public BasedModel()
        {
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public Guid? Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}