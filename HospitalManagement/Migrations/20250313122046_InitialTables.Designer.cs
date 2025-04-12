﻿// <auto-generated />
using System;
using HospitalManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalManagement.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20250313122046_InitialTables")]
    partial class InitialTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("appointment_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointment_date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("AppointmentId")
                        .HasName("pk_appointments");

                    b.HasIndex("DoctorId")
                        .HasDatabaseName("ix_appointments_doctor_id");

                    b.HasIndex("PatientId")
                        .HasDatabaseName("ix_appointments_patient_id");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("integer")
                        .HasColumnName("speciality_id");

                    b.HasKey("DoctorId")
                        .HasName("pk_doctors");

                    b.HasIndex("SpecialityId")
                        .HasDatabaseName("ix_doctors_speciality_id");

                    b.ToTable("doctors", (string)null);
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientId"));

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<int?>("PatientBlankId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_blank_id");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registered_date");

                    b.HasKey("PatientId")
                        .HasName("pk_patients");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.PatientBlank", b =>
                {
                    b.Property<int>("PatientBlankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("patient_blank_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientBlankId"));

                    b.Property<string>("BlankIdentifier")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("blank_identifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("PatientBlankId")
                        .HasName("pk_patient_blank");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasDatabaseName("ix_patient_blank_patient_id");

                    b.ToTable("patient_blank", (string)null);
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Speciality", b =>
                {
                    b.Property<int>("SpecialityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("speciality_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecialityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("SpecialityId")
                        .HasName("pk_speciality");

                    b.ToTable("speciality", (string)null);
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Appointment", b =>
                {
                    b.HasOne("HospitalManagement.DataAccess.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_doctors_doctor_id");

                    b.HasOne("HospitalManagement.DataAccess.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_patients_patient_id");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Doctor", b =>
                {
                    b.HasOne("HospitalManagement.DataAccess.Entities.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_doctors_speciality_speciality_id");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.PatientBlank", b =>
                {
                    b.HasOne("HospitalManagement.DataAccess.Entities.Patient", "Patient")
                        .WithOne("PatientBlank")
                        .HasForeignKey("HospitalManagement.DataAccess.Entities.PatientBlank", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patient_blank_patients_patient_id");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HospitalManagement.DataAccess.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("PatientBlank");
                });
#pragma warning restore 612, 618
        }
    }
}
