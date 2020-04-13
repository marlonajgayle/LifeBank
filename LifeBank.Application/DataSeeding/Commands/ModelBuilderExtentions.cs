using LifeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeBank.Application.DataSeeding.Commands
{
    public static class ModelBuilderExtentions
    {
        public static void SeedParishData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parish>().HasData(
                    new Parish()
                    {
                        ParishId = 1,
                        ParishName = "Hanover"
                    },
                    new Parish()
                    {
                        ParishId = 2,
                        ParishName = "St. Elizabeth"
                    },
                    new Parish()
                    {
                        ParishId = 3,
                        ParishName = "St. James"
                    },
                    new Parish()
                    {
                        ParishId = 4,
                        ParishName = "Trelawny"
                    },
                    new Parish()
                    {
                        ParishId = 5,
                        ParishName = "Westmoreland"
                    },
                    new Parish()
                    {
                        ParishId = 6,
                        ParishName = "Clarendon"
                    },
                    new Parish()
                    {
                        ParishId = 7,
                        ParishName = "Manchester"
                    },
                    new Parish()
                    {
                        ParishId = 8,
                        ParishName = "St. Ann"
                    },
                    new Parish()
                    {
                        ParishId = 9,
                        ParishName = "St. Catherine"
                    },
                    new Parish()
                    {
                        ParishId = 10,
                        ParishName = "St. Mary"
                    }, new Parish()
                    {
                        ParishId = 11,
                        ParishName = "Kingston"
                    }, new Parish()
                    {
                        ParishId = 12,
                        ParishName = "Portland"
                    }, new Parish()
                    {
                        ParishId = 13,
                        ParishName = "St. Andrew"
                    }, new Parish()
                    {
                        ParishId = 14,
                        ParishName = "St. Thomas"
                    }
                );
        }

        public static void SeedBloodTypeData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodType>().HasData(
                    new BloodType()
                    { 
                        BloodTypeId = 1,
                        BloodGroup = "O-"                    
                    }, new BloodType()
                    {
                        BloodTypeId = 2,
                        BloodGroup = "O+"
                    }, new BloodType()
                    {
                        BloodTypeId = 3,
                        BloodGroup = "B-"
                    }, new BloodType()
                    {
                        BloodTypeId = 4,
                        BloodGroup = "B+"
                    }, new BloodType()
                    {
                        BloodTypeId = 5,
                        BloodGroup = "A-"
                    }, new BloodType()
                    {
                        BloodTypeId = 6,
                        BloodGroup = "A+"
                    }, new BloodType()
                    {
                        BloodTypeId = 7,
                        BloodGroup = "AB-"
                    }, new BloodType()
                    {
                        BloodTypeId = 8,
                        BloodGroup = "AB+"
                    }
                );
        }
    }
}
