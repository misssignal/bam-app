using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NpgsqlTypes.NpgsqlTsVector;
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BAM_Learning.Helpers
{
    internal class ClsDatabaseNotes
    {
        // https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Modeling
        // https://dev.to/vzldev/integrating-postgresql-with-a-net-a-step-by-step-guide-3hep

        // Defining the primary key for entire data model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.UseIdentityByDefaultColumns();

        // Defining the primary key strategy for a single property

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Blog>().Property(b => b.Id).UseIdentityAlwaysColumn();


        // Creating primary keys yourself (identity) versus with the database:
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Blog>().Property(b => b.Id)
        .HasIdentityOptions(startValue: 100);

        // Other types of sequencing, like with order numbers
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("OrderNumbers")
                        .StartsAt(1000)
                        .IncrementsBy(5);

            modelBuilder.Entity<Order>()
                        .Property(o => o.OrderNo)
                        .HasDefaultValueSql("nextval('\"OrderNumbers\"')");
        }


        // Using a HiLo only for a certain attribute or field
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Blog>()
                   .Property(b => b.Id)
                   .UseHiLo();

        // Using a HiLo to have primary keys reserved in chunks to reduce additional read and writes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.UseHiLo();



        // How to create a UUID/GUID
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Blog>()
                .Property(b => b.SomeGuidProperty)
                .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Blog>()
                .Property(e => e.SomeDateTimeProperty)
                .HasDefaultValueSql("now()");
        }
      /*CREATE FUNCTION "Blogs_Update_Timestamp_Function"() RETURNS TRIGGER LANGUAGE PLPGSQL AS $$
        BEGIN
            NEW."Timestamp" := now();
                RETURN NEW;
                END;
        $$;*/



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Blog>()
                .Property(e => e.SomeGuidProperty)
                .HasDefaultValueSql("gen_random_uuid()");
        }

        /*CREATE TRIGGER "UpdateTimestamp"
          BEFORE INSERT OR UPDATE
          ON "Blogs"
          FOR EACH ROW
          EXECUTE FUNCTION "Blogs_Update_Timestamp_Function"();*/


        // TSVECTOR Searching is an available option to do partial matching of text in a db quickly.

       /* A tsvector is a sorted list of distinct lexemes, which are words that have been normalized to merge different forms of the same word(e.g., “run” and “running”).
        --PostgreSQL provides functions to convert plain text into tsvector format, which typically involves:
          -Parsing the text into tokens.
          -Converting tokens to lexemes.
          -Removing stop words (common words like “and” or “the” that are typically ignored in searches).
        Example: The text “The quick brown fox” might be represented in tsvector as ‘brown’:3 ‘fox’:4 ‘quick’:2*/
    }
}
