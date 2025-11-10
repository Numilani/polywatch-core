using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace polywatchcore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GDELTEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Actor1_Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_CountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_KnownGroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_EthnicCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_ReligionCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_ReligionSubgroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_TypeCodeA = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_TypeCodeB = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1_TypeCodeC = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_CountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_KnownGroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_EthnicCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_ReligionCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_ReligionSubgroupCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_TypeCodeA = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_TypeCodeB = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2_TypeCodeC = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1Geodata_GeoType = table.Column<int>(type: "INTEGER", nullable: true),
                    Actor1Geodata_GeoName = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1Geodata_CountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1Geodata_ADM1Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1Geodata_ADM2Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor1Geodata_Latitude = table.Column<float>(type: "REAL", nullable: true),
                    Actor1Geodata_Longitude = table.Column<float>(type: "REAL", nullable: true),
                    Actor1Geodata_FeatureID = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2Geodata_GeoType = table.Column<int>(type: "INTEGER", nullable: true),
                    Actor2Geodata_GeoName = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2Geodata_CountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2Geodata_ADM1Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2Geodata_ADM2Code = table.Column<string>(type: "TEXT", nullable: true),
                    Actor2Geodata_Latitude = table.Column<float>(type: "REAL", nullable: true),
                    Actor2Geodata_Longitude = table.Column<float>(type: "REAL", nullable: true),
                    Actor2Geodata_FeatureID = table.Column<string>(type: "TEXT", nullable: true),
                    ActionGeodata_GeoType = table.Column<int>(type: "INTEGER", nullable: true),
                    ActionGeodata_GeoName = table.Column<string>(type: "TEXT", nullable: true),
                    ActionGeodata_CountryCode = table.Column<string>(type: "TEXT", nullable: true),
                    ActionGeodata_ADM1Code = table.Column<string>(type: "TEXT", nullable: true),
                    ActionGeodata_ADM2Code = table.Column<string>(type: "TEXT", nullable: true),
                    ActionGeodata_Latitude = table.Column<float>(type: "REAL", nullable: true),
                    ActionGeodata_Longitude = table.Column<float>(type: "REAL", nullable: true),
                    ActionGeodata_FeatureID = table.Column<string>(type: "TEXT", nullable: true),
                    IsRootEvent = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventCode = table.Column<string>(type: "TEXT", nullable: false),
                    QuadClass = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldsteinScale = table.Column<float>(type: "REAL", nullable: false),
                    AverageTone = table.Column<float>(type: "REAL", nullable: false),
                    TotalMentionsAtUpdate = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSourcesAtUpdate = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalArticlesAtUpdate = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SourceUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GDELTEvents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GDELTEvents");
        }
    }
}
