﻿using Microsoft.EntityFrameworkCore;
using taskboard_api.Models;

namespace taskboard_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}