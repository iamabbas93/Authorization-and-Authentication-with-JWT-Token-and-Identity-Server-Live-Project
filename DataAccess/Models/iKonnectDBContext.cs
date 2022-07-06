using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Models
{
    public partial class iKonnectDBContext : DbContext
    {
        public iKonnectDBContext()
        {
        }

        public iKonnectDBContext(DbContextOptions<iKonnectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddress> TblAddresses { get; set; }
        public virtual DbSet<TblAlarm> TblAlarms { get; set; }
        public virtual DbSet<TblDevice> TblDevices { get; set; }
        public virtual DbSet<TblFacility> TblFacilities { get; set; }
        public virtual DbSet<TblHealthDatum> TblHealthData { get; set; }
        public virtual DbSet<TblLocation> TblLocations { get; set; }
        public virtual DbSet<TblMetaDatum> TblMetaData { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TblPhysician> TblPhysicians { get; set; }
        public virtual DbSet<TblThreshold> TblThresholds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\LocalDBDemo;Database=iKonnectDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("tblAddresses");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.Address1)
                    .HasMaxLength(250)
                    .HasColumnName("address1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(250)
                    .HasColumnName("address2");

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .HasColumnName("country");

                entity.Property(e => e.State)
                    .HasMaxLength(150)
                    .HasColumnName("state");

                entity.Property(e => e.Zip).HasColumnName("zip");
            });

            modelBuilder.Entity<TblAlarm>(entity =>
            {
                entity.HasKey(e => e.AlarmId);

                entity.ToTable("tblAlarms");

                entity.Property(e => e.AlarmId).HasColumnName("alarmId");

                entity.Property(e => e.DiffDays)
                    .HasMaxLength(50)
                    .HasColumnName("diffDays");

                entity.Property(e => e.GreaterThan).HasColumnName("greaterThan");

                entity.Property(e => e.LastReading)
                    .HasMaxLength(50)
                    .HasColumnName("lastReading");

                entity.Property(e => e.LessThan).HasColumnName("lessThan");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TblDevice>(entity =>
            {
                entity.HasKey(e => e.IkDeviceId);

                entity.ToTable("tblDevice");

                entity.Property(e => e.IkDeviceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ikDeviceId");

                entity.Property(e => e.BatteryLevel).HasColumnName("batteryLevel");

                entity.Property(e => e.BatteryUpdatedOn).HasColumnName("batteryUpdatedOn");

                entity.Property(e => e.Btmac)
                    .HasMaxLength(250)
                    .HasColumnName("btmac");

                entity.Property(e => e.Btname)
                    .HasMaxLength(250)
                    .HasColumnName("btname");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtMillis).HasColumnName("createdAtMillis");

                entity.Property(e => e.CreatedAtMills).HasColumnName("createdAtMills");

                entity.Property(e => e.LcAcountId)
                    .HasMaxLength(100)
                    .HasColumnName("lcAcountId");

                entity.Property(e => e.LcDeviceId).HasColumnName("lcDeviceId");

                entity.Property(e => e.LcFacilityId)
                    .HasMaxLength(100)
                    .HasColumnName("lcFacilityId");

                entity.Property(e => e.LcPatientId)
                    .HasMaxLength(150)
                    .HasColumnName("lcPatientId");

                entity.Property(e => e.LocId).HasColumnName("locId");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(250)
                    .HasColumnName("serialNumber");

                entity.Property(e => e.SimNumber)
                    .HasMaxLength(250)
                    .HasColumnName("simNumber");

                entity.Property(e => e.Status)
                    .HasMaxLength(150)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(150)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtMillis).HasColumnName("updatedAtMillis");

                entity.Property(e => e.UpdatedAtMills).HasColumnName("updatedAtMills");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.TblDevices)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK_tblDevice_tblLocation");
            });

            modelBuilder.Entity<TblFacility>(entity =>
            {
                entity.HasKey(e => e.IkFacilityId);

                entity.ToTable("tblFacilities");

                entity.HasIndex(e => e.LcAcountId, "IX_tblFacilities")
                    .IsUnique();

                entity.Property(e => e.IkFacilityId).HasColumnName("ikFacilityId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.Aide).HasColumnName("aide");

                entity.Property(e => e.BillingEmail)
                    .HasMaxLength(100)
                    .HasColumnName("billingEmail");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtMills).HasColumnName("createdAtMills");

                entity.Property(e => e.FacilityType)
                    .HasMaxLength(100)
                    .HasColumnName("facilityType");

                entity.Property(e => e.Help).HasColumnName("help");

                entity.Property(e => e.IsMain).HasColumnName("isMain");

                entity.Property(e => e.LcAcountId)
                    .IsRequired()
                    .HasColumnName("lcAcountId");

                entity.Property(e => e.LcFacilityId)
                    .HasMaxLength(100)
                    .HasColumnName("lcFacilityId");

                entity.Property(e => e.Medical).HasColumnName("medical");

                entity.Property(e => e.MetaDataId).HasColumnName("metaDataId");

                entity.Property(e => e.NameOfFacility)
                    .HasMaxLength(100)
                    .HasColumnName("nameOfFacility");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtMills).HasColumnName("updatedAtMills");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TblFacilities)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_tblFacilities_tblAddresses");

                entity.HasOne(d => d.MetaData)
                    .WithMany(p => p.TblFacilities)
                    .HasForeignKey(d => d.MetaDataId)
                    .HasConstraintName("FK_tblFacilities_tblMetaData");
            });

            modelBuilder.Entity<TblHealthDatum>(entity =>
            {
                entity.HasKey(e => e.HdId);

                entity.ToTable("tblHealthData");

                entity.Property(e => e.HdId).HasColumnName("hdId");

                entity.Property(e => e.Btid).HasColumnName("btid");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.Dia)
                    .HasMaxLength(50)
                    .HasColumnName("dia");

                entity.Property(e => e.LcDeviceId).HasColumnName("lcDeviceId");

                entity.Property(e => e.LcPatientId)
                    .HasMaxLength(150)
                    .HasColumnName("lcPatientId");

                entity.Property(e => e.Oxygen)
                    .HasMaxLength(50)
                    .HasColumnName("oxygen");

                entity.Property(e => e.Pulse)
                    .HasMaxLength(50)
                    .HasColumnName("pulse");

                entity.Property(e => e.SecondaryId).HasColumnName("secondaryID");

                entity.Property(e => e.Sys)
                    .HasMaxLength(50)
                    .HasColumnName("sys");
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocId);

                entity.ToTable("tblLocation");

                entity.Property(e => e.LocId).HasColumnName("locId");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.LcDeviceId).HasColumnName("lcDeviceId");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            modelBuilder.Entity<TblMetaDatum>(entity =>
            {
                entity.HasKey(e => e.MetaDataId);

                entity.ToTable("tblMetaData");

                entity.Property(e => e.MetaDataId).HasColumnName("metaDataId");

                entity.Property(e => e.IkFacilityId).HasColumnName("ikFacilityId");

                entity.Property(e => e.LcFacilityId).HasColumnName("lcFacilityId");

                entity.Property(e => e.LcMyMetaData).HasColumnName("lcMyMetaData");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PtId);

                entity.ToTable("tblPatients");

                entity.Property(e => e.PtId).HasColumnName("ptId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtMills).HasColumnName("createdAtMills");

                entity.Property(e => e.CustomerConsentTimestamp).HasColumnName("customerConsentTimestamp");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.DeviceLanguage)
                    .HasMaxLength(50)
                    .HasColumnName("deviceLanguage");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.LcAcountId).HasColumnName("lcAcountId");

                entity.Property(e => e.LcFacilityId)
                    .HasMaxLength(100)
                    .HasColumnName("lcFacilityId");

                entity.Property(e => e.LcPatientId)
                    .HasMaxLength(150)
                    .HasColumnName("lcPatientId");

                entity.Property(e => e.LcSecondaryId)
                    .HasMaxLength(150)
                    .HasColumnName("lcSecondaryId");

                entity.Property(e => e.LcUserId)
                    .HasMaxLength(50)
                    .HasColumnName("lcUserId");

                entity.Property(e => e.LcdeviceId).HasColumnName("lcdeviceId");

                entity.Property(e => e.MetaDataId).HasColumnName("metaDataId");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .HasColumnName("middleName");

                entity.Property(e => e.Mrn)
                    .HasMaxLength(150)
                    .HasColumnName("mrn");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.Subscription).HasColumnName("subscription");

                entity.Property(e => e.Telecom)
                    .HasMaxLength(100)
                    .HasColumnName("telecom");

                entity.Property(e => e.TermsAndConditionTimestamp).HasColumnName("termsAndConditionTimestamp");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtMills).HasColumnName("updatedAtMills");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_tblPatients_tblAddresses");
            });

            modelBuilder.Entity<TblPhysician>(entity =>
            {
                entity.HasKey(e => e.PhysicianId);

                entity.ToTable("tblPhysicians");

                entity.Property(e => e.PhysicianId).HasColumnName("physicianId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.LcAcountId).HasColumnName("lcAcountId");

                entity.Property(e => e.LcUserId)
                    .HasMaxLength(250)
                    .HasColumnName("lcUserId");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .HasColumnName("middleName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(150)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Status)
                    .HasMaxLength(150)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TblPhysicians)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_tblPhysicians_tblAddresses");

                entity.HasOne(d => d.LcAcount)
                    .WithMany(p => p.TblPhysicians)
                    .HasPrincipalKey(p => p.LcAcountId)
                    .HasForeignKey(d => d.LcAcountId)
                    .HasConstraintName("FK_tblPhysicians_tblPhysicians");
            });

            modelBuilder.Entity<TblThreshold>(entity =>
            {
                entity.HasKey(e => e.FacThresId)
                    .HasName("PK_facThreshold");

                entity.ToTable("tblThreshold");

                entity.Property(e => e.FacThresId).HasColumnName("facThresId");

                entity.Property(e => e.Acronym)
                    .HasMaxLength(150)
                    .HasColumnName("acronym");

                entity.Property(e => e.AlarmCcId).HasColumnName("alarmCcId");

                entity.Property(e => e.AlarmId).HasColumnName("alarmId");

                entity.Property(e => e.AlertId).HasColumnName("alertId");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.LcLevelId).HasColumnName("lcLevelId");

                entity.Property(e => e.LcPatientId)
                    .HasMaxLength(150)
                    .HasColumnName("lcPatientId");

                entity.Property(e => e.LcThresholdId).HasColumnName("lcThresholdId");

                entity.Property(e => e.MaxValue).HasColumnName("maxValue");

                entity.Property(e => e.MinValue).HasColumnName("minValue");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.NotMerge).HasColumnName("notMerge");

                entity.Property(e => e.SetBy)
                    .HasMaxLength(150)
                    .HasColumnName("setBy");

                entity.Property(e => e.Source)
                    .HasMaxLength(150)
                    .HasColumnName("source");

                entity.Property(e => e.StagesId).HasColumnName("stagesId");

                entity.Property(e => e.Status)
                    .HasMaxLength(150)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(150)
                    .HasColumnName("type");

                entity.Property(e => e.Uom)
                    .HasMaxLength(50)
                    .HasColumnName("uom");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
