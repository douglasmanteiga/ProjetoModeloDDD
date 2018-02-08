namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoModeloDDD.Infra.Data.Context.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoModeloContext context)
        {

        }
    }
}
