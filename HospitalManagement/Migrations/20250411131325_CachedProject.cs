using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class CachedProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_appointments_doctors_doctor_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "fk_appointments_patients_patient_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "fk_doctors_speciality_speciality_id",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_patient_blank_patients_patient_id",
                table: "patient_blank");

            migrationBuilder.DropPrimaryKey(
                name: "pk_speciality",
                table: "speciality");

            migrationBuilder.DropPrimaryKey(
                name: "pk_patients",
                table: "patients");

            migrationBuilder.DropPrimaryKey(
                name: "pk_doctors",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_appointments",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_patient_blank",
                table: "patient_blank");

            migrationBuilder.RenameTable(
                name: "speciality",
                newName: "Speciality");

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointments");

            migrationBuilder.RenameTable(
                name: "patient_blank",
                newName: "PatientBlank");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Speciality",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "speciality_id",
                table: "Speciality",
                newName: "SpecialityId");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Patients",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Patients",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "registered_date",
                table: "Patients",
                newName: "RegisteredDate");

            migrationBuilder.RenameColumn(
                name: "patient_blank_id",
                table: "Patients",
                newName: "PatientBlankId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Patients",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "Patients",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Patients",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Doctors",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Doctors",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "speciality_id",
                table: "Doctors",
                newName: "SpecialityId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Doctors",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "Doctors",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "ix_doctors_speciality_id",
                table: "Doctors",
                newName: "IX_Doctors_SpecialityId");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Appointments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "appointment_date",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.RenameColumn(
                name: "appointment_id",
                table: "Appointments",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "ix_appointments_patient_id",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "ix_appointments_doctor_id",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.RenameColumn(
                name: "severity",
                table: "PatientBlank",
                newName: "Severity");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "PatientBlank",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "PatientBlank",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PatientBlank",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "blank_identifier",
                table: "PatientBlank",
                newName: "BlankIdentifier");

            migrationBuilder.RenameColumn(
                name: "patient_blank_id",
                table: "PatientBlank",
                newName: "PatientBlankId");

            migrationBuilder.RenameIndex(
                name: "ix_patient_blank_patient_id",
                table: "PatientBlank",
                newName: "IX_PatientBlank_PatientId");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speciality",
                table: "Speciality",
                column: "SpecialityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientBlank",
                table: "PatientBlank",
                column: "PatientBlankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Speciality_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Speciality",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientBlank_Patients_PatientId",
                table: "PatientBlank",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Speciality_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientBlank_Patients_PatientId",
                table: "PatientBlank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speciality",
                table: "Speciality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientBlank",
                table: "PatientBlank");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Speciality",
                newName: "speciality");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "patients");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "doctors");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "appointments");

            migrationBuilder.RenameTable(
                name: "PatientBlank",
                newName: "patient_blank");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "speciality",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "speciality",
                newName: "speciality_id");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "patients",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "patients",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "patients",
                newName: "registered_date");

            migrationBuilder.RenameColumn(
                name: "PatientBlankId",
                table: "patients",
                newName: "patient_blank_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "patients",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "patients",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "patients",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "doctors",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "doctors",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "doctors",
                newName: "speciality_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "doctors",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "doctors",
                newName: "doctor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialityId",
                table: "doctors",
                newName: "ix_doctors_speciality_id");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "appointments",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "appointments",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "appointments",
                newName: "doctor_id");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "appointments",
                newName: "appointment_date");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "appointments",
                newName: "appointment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "appointments",
                newName: "ix_appointments_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "appointments",
                newName: "ix_appointments_doctor_id");

            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "patient_blank",
                newName: "severity");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "patient_blank",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "patient_blank",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "patient_blank",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "BlankIdentifier",
                table: "patient_blank",
                newName: "blank_identifier");

            migrationBuilder.RenameColumn(
                name: "PatientBlankId",
                table: "patient_blank",
                newName: "patient_blank_id");

            migrationBuilder.RenameIndex(
                name: "IX_PatientBlank_PatientId",
                table: "patient_blank",
                newName: "ix_patient_blank_patient_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_speciality",
                table: "speciality",
                column: "speciality_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_patients",
                table: "patients",
                column: "patient_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_doctors",
                table: "doctors",
                column: "doctor_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_appointments",
                table: "appointments",
                column: "appointment_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_patient_blank",
                table: "patient_blank",
                column: "patient_blank_id");

            migrationBuilder.AddForeignKey(
                name: "fk_appointments_doctors_doctor_id",
                table: "appointments",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_appointments_patients_patient_id",
                table: "appointments",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_speciality_speciality_id",
                table: "doctors",
                column: "speciality_id",
                principalTable: "speciality",
                principalColumn: "speciality_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_patient_blank_patients_patient_id",
                table: "patient_blank",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
