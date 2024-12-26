using System;
using System.Collections.Generic;
using CAPA_ENTIDAD;
using Microsoft.EntityFrameworkCore;

namespace RegistroEpidemiologico;

public partial class SghrhContext : DbContext
{
    public SghrhContext()
    {
    }

    public SghrhContext(DbContextOptions<SghrhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antibiotico> Antibioticos { get; set; }

    public virtual DbSet<CamaPaciente> CamaPacientes { get; set; }

    public virtual DbSet<Cie10> Cie10s { get; set; }

    public virtual DbSet<DatosEpidemiologium> DatosEpidemiologia { get; set; }

    public virtual DbSet<DatosMadre> DatosMadre { get; set; }

    public virtual DbSet<DatosNeonato> DatosNeonato { get; set; }

    public virtual DbSet<DatosVigilancium> DatosVigilancia { get; set; }

    public virtual DbSet<Dependencium> Dependencia { get; set; }

    public virtual DbSet<DispositivosMedico> DispositivosMedicos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Historium> Historia { get; set; }

    public virtual DbSet<Microbiologium> Microbiologia { get; set; }

    public virtual DbSet<ReporteEpidemiologico> ReporteEpidemiologico { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioDispositivosMedico> ServicioDispositivosMedicos { get; set; }

    public virtual DbSet<Ubicacioncama> Ubicacioncamas { get; set; }

    public virtual DbSet<VigilanciaEpidemiologica> VigilanciaEpidemiologica { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Especialidad> Especialidades { get; set; }

    public virtual DbSet<Subarea> Subareas { get; set; }


    public virtual DbSet<CieSemm> CieSemms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:cn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antibiotico>(entity =>
        {
            entity.HasKey(e => e.IdAntibiotico).HasName("PK__antibiot__F01F7678D8B44391");

            entity.ToTable("antibiotico");

            entity.Property(e => e.IdAntibiotico).HasColumnName("ID_antibiotico");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NombreAntibiotico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_antibiotico");
        });

        modelBuilder.Entity<CamaPaciente>(entity =>
        {
            entity.HasKey(e => e.IdCamaPaciente).HasName("PK__cama_pac__1E50FBE5B1021877");

            entity.ToTable("cama_paciente");

            entity.Property(e => e.IdCamaPaciente).HasColumnName("ID_cama_paciente");
            entity.Property(e => e.Antivo).HasColumnName("activo");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdCama).HasColumnName("ID_cama");
            entity.Property(e => e.IdPaciente)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_paciente");

            entity.HasOne(d => d.IdCamaNavigation).WithMany(p => p.CamaPacientes)
                .HasForeignKey(d => d.IdCama)
                .HasConstraintName("FK_cama_paciente_ubicacioncama");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.CamaPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK_cama_paciente_historia");
        });

        modelBuilder.Entity<Cie10>(entity =>
        {
            entity.HasKey(e => e.Idcie10);

            entity.ToTable("cie10");

            entity.HasIndex(e => e.Tcie, "tcie");

            entity.Property(e => e.Idcie10).HasColumnName("idcie10");
            entity.Property(e => e.CodDepen)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_depen");
            entity.Property(e => e.CodEspec)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_espec");
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descrip)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("descrip");
            entity.Property(e => e.EMax)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("e_max");
            entity.Property(e => e.EMin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("e_min");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .HasColumnName("estado");
            entity.Property(e => e.NivcptI)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nivcpt_i");
            entity.Property(e => e.NivcptIi)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nivcpt_ii");
            entity.Property(e => e.NivcptIii)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nivcpt_iii");
            entity.Property(e => e.NivcptIv)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nivcpt_iv");
            entity.Property(e => e.NivcptV)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nivcpt_v");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.Tcie)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tcie");
            entity.Property(e => e.TeMax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("te_max");
            entity.Property(e => e.TeMin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("te_min");
        });

        modelBuilder.Entity<DatosEpidemiologium>(entity =>
        {
            entity.HasKey(e => e.IdDatos).HasName("PK__datos__F80AAF1B716686B1");

            entity.ToTable("datos_epidemiologia");

            entity.Property(e => e.IdDatos).HasColumnName("ID_datos");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
        });

        modelBuilder.Entity<DatosMadre>(entity =>
        {
            entity.HasKey(e => e.IdDatosMadre).HasName("PK__datos_ma__3381360C59A3AA86");

            entity.ToTable("datos_madre");

            entity.Property(e => e.IdDatosMadre).HasColumnName("ID_datos_madre");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.TipoLiquidoAmniotico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_liquido_amniotico");
            entity.Property(e => e.TipoParto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_parto");
        });

        modelBuilder.Entity<DatosNeonato>(entity =>
        {
            entity.HasKey(e => e.IdDatosNeonato).HasName("PK__datos_ne__831B0778226913BC");

            entity.ToTable("datos_neonato");

            entity.Property(e => e.IdDatosNeonato).HasColumnName("ID_datos_neonato");
            entity.Property(e => e.Apgan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apgan");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PerimetroAbdominal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perimetro_abdominal");
            entity.Property(e => e.PerimetroCefaleo)
                .HasMaxLength(244)
                .IsUnicode(false)
                .HasColumnName("perimetro_cefaleo");
            entity.Property(e => e.PerimetroToraxico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perimetro_toraxico");
        });

        modelBuilder.Entity<DatosVigilancium>(entity =>
        {
            entity.HasKey(e => e.IdDatosVigilancia).HasName("PK__datos_vi__102C49618060DE46");

            entity.ToTable("datos_vigilancia");

            entity.Property(e => e.IdDatosVigilancia).HasColumnName("ID_datos_vigilancia");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Datos).HasColumnName("datos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdDatos).HasColumnName("ID_datos");
            entity.Property(e => e.IdServicioDispositivoMedico).HasColumnName("ID_servicio_dispositivo_medico");

            entity.HasOne(d => d.IdDatosNavigation).WithMany(p => p.DatosVigilancia)
                .HasForeignKey(d => d.IdDatos)
                .HasConstraintName("FK__datos_vig__ID_da__42501F7D");

            entity.HasOne(d => d.IdServicioDispositivoMedicoNavigation).WithMany(p => p.DatosVigilancia)
                .HasForeignKey(d => d.IdServicioDispositivoMedico)
                .HasConstraintName("FK__datos_vig__ID_se__3D8B6A60");
        });

        modelBuilder.Entity<Dependencium>(entity =>
        {
            entity.HasKey(e => e.CodDepen);

            entity.ToTable("dependencia");

            entity.Property(e => e.CodDepen)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_depen");
            entity.Property(e => e.NombreDependencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_dependencia");
            entity.Property(e => e.Tipotexto)
                .HasColumnType("text")
                .HasColumnName("tipotexto");
        });

        modelBuilder.Entity<DispositivosMedico>(entity =>
        {
            entity.HasKey(e => e.IdDispositivosMedicos).HasName("PK__disposit__F3F46CEDFD9747D0");

            entity.ToTable("dispositivos_medicos");

            entity.Property(e => e.IdDispositivosMedicos).HasColumnName("ID_dispositivos_medicos");
            entity.Property(e => e.Abreviatura)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("abreviatura");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NombreDispositivosMedicos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_dispositivos_medicos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__empleado__EE7D5EF66418C597");

            entity.ToTable("empleado");

            entity.Property(e => e.Idempleado)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("idempleado");
            entity.Property(e => e.Apematerno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apematerno");
            entity.Property(e => e.Apepaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apepaterno");
            entity.Property(e => e.Cargo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Celular)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("celular");
            entity.Property(e => e.CodigoRne1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_rne1");
            entity.Property(e => e.CodigoRne2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_rne2");
            entity.Property(e => e.Especialidad1).HasColumnName("especialidad1");
            entity.Property(e => e.Especialidad2).HasColumnName("especialidad2");
            entity.Property(e => e.Idespegeneral)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("idespegeneral");
            entity.Property(e => e.Idespegeneral2)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("idespegeneral2");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Nrocolegiatura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nrocolegiatura");
            entity.Property(e => e.Profesion).HasColumnName("profesion");
            entity.Property(e => e.Tipoplaza)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipoplaza");
        });

        modelBuilder.Entity<Historium>(entity =>
        {
            entity.HasKey(e => e.Dni);

            entity.ToTable("historia");

            entity.HasIndex(e => new { e.ApePaterno, e.ApeMaterno, e.Nombres }, "IX_HISTORIA").HasFillFactor(90);

            entity.HasIndex(e => e.Nhc, "ix_NHC");

            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.AcompDni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ACOMP_DNI");
            entity.Property(e => e.AcompDom)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("ACOMP_DOM");
            entity.Property(e => e.ApeCasada)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APE_CASADA");
            entity.Property(e => e.ApeMaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .HasColumnName("APE_MATERNO");
            entity.Property(e => e.ApePaterno)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .HasColumnName("APE_PATERNO");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.DistDom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIST_DOM");
            entity.Property(e => e.DistNac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIST_NAC");
            entity.Property(e => e.DistPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIST_PRO");
            entity.Property(e => e.DomActual)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("DOM_ACTUAL");
            entity.Property(e => e.DptoDom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DPTO_DOM");
            entity.Property(e => e.DptoNac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DPTO_NAC");
            entity.Property(e => e.DptoPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DPTO_PRO");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.EstCiv)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EST_CIV");
            entity.Property(e => e.EstadoPaciente)
                .HasMaxLength(350)
                .HasColumnName("estado_paciente");
            entity.Property(e => e.Etnia)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ETNIA");
            entity.Property(e => e.FecNac)
                .HasColumnType("datetime")
                .HasColumnName("FEC_NAC");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaModificado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificado");
            entity.Property(e => e.GradInst)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GRAD_INST");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NACIONALIDAD");
            entity.Property(e => e.Nhc).HasColumnName("NHC");
            entity.Property(e => e.NomMad)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOM_MAD");
            entity.Property(e => e.NomPad)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOM_PAD");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .HasColumnName("NOMBRES");
            entity.Property(e => e.NumSeg)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NUM_SEG");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
            entity.Property(e => e.Ocup)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OCUP");
            entity.Property(e => e.ProvDom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROV_DOM");
            entity.Property(e => e.ProvNac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROV_NAC");
            entity.Property(e => e.ProvPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROV_PRO");
            entity.Property(e => e.Religion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("RELIGION");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEXO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.TipoSeg)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TIPO_SEG");
            entity.Property(e => e.TipodocIdentidad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipodoc_identidad");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ubigeo");
            entity.Property(e => e.UsuarioModificado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usuario_modificado");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usuario_registro");
        });

        modelBuilder.Entity<Microbiologium>(entity =>
        {
            entity.HasKey(e => e.IdMicrobiologia).HasName("PK__microbio__430B1404DFE5D330");

            entity.ToTable("microbiologia");

            entity.Property(e => e.IdMicrobiologia).HasColumnName("ID_microbiologia");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NombreMicrobiologia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_microbiologia");
        });

        modelBuilder.Entity<ReporteEpidemiologico>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__reporte___41AEEB64FA0766FB");

            entity.ToTable("reporte_epidemiologico");

            entity.Property(e => e.IdReporte).HasColumnName("ID_reporte");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FechaGeneracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.IdCamaPaciente).HasColumnName("ID_cama_paciente");
            entity.Property(e => e.IdDatos).HasColumnName("ID_datos");
            entity.Property(e => e.IdDatosMadre).HasColumnName("ID_datos_madre");
            entity.Property(e => e.IdDatosNeonato).HasColumnName("ID_datos_neonato");
            entity.Property(e => e.IdDependencia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_dependencia");
            entity.Property(e => e.IdDniPaciente)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ID_DNI_paciente");
            entity.Property(e => e.IdDniPersonalSalud)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ID_DNI_personal_salud");
            entity.Property(e => e.DxIngreso).HasColumnName("Dx_ingreso");
            entity.Property(e => e.IdServicio)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_servicio");
            entity.Property(e => e.IdVigilancia).HasColumnName("ID_vigilancia");

            entity.HasOne(d => d.IdCamaPacienteNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdCamaPaciente)
                .HasConstraintName("FK_reporte_epidemiologico_reporte_epidemiologico");

            entity.HasOne(d => d.IdDatosNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdDatos)
                .HasConstraintName("FK__reporte_e__ID_da__3F73B2D2");

            entity.HasOne(d => d.IdDatosMadreNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdDatosMadre)
                .HasConstraintName("FK__reporte_e__ID_da__415BFB44");

            entity.HasOne(d => d.IdDatosNeonatoNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdDatosNeonato)
                .HasConstraintName("FK__reporte_e__ID_da__4067D70B");

            entity.HasOne(d => d.IdDniPersonalSaludNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdDniPersonalSalud)
                .HasConstraintName("FK_reporte_epidemiologico_empleado");

            entity.HasOne(d => d.IdVigilanciaNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdVigilancia)
                .HasConstraintName("FK__reporte_e__ID_vi__3E7F8E99");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => new { d.IdDependencia, d.IdServicio })
                .HasConstraintName("FK_reporte_epidemiologico_servicio");

            entity.HasOne(d => d.IdDniPacienteNavigation).WithMany(p => p.ReporteEpidemiologicos)
                .HasForeignKey(d => d.IdDniPaciente)
                .HasConstraintName("FK_reporte_epidemiologico_historia");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => new { e.CodDepen, e.CodServi }).HasName("PK__servicio__3D6B26B466F53242");

            entity.ToTable("servicio");

            entity.Property(e => e.CodDepen)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_depen");
            entity.Property(e => e.CodServi)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_servi");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");

            entity.HasOne(d => d.CodDepenNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.CodDepen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__servicio__cod_de__6BB9E75F");
        });

        modelBuilder.Entity<ServicioDispositivosMedico>(entity =>
        {
            entity.HasKey(e => e.IdServicioDispositivosMedicos).HasName("PK__servicio__DDA0B02E07517485");

            entity.ToTable("servicio_dispositivos_medicos");

            entity.Property(e => e.IdServicioDispositivosMedicos).HasColumnName("ID_servicio_dispositivos_medicos");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            entity.Property(e => e.IdDispositivosMedicos).HasColumnName("ID_dispositivos_medicos");

            entity.HasOne(d => d.IdDispositivosMedicosNavigation).WithMany(p => p.ServicioDispositivosMedicos)
                .HasForeignKey(d => d.IdDispositivosMedicos)
                .HasConstraintName("FK__servicio___ID_di__3C974627");

            entity.Property(e => e.IdServicio)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_servicio");

            entity.Property(e => e.IdDependencia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("04")
                .HasColumnName("ID_dependencia");
        });

        modelBuilder.Entity<Ubicacioncama>(entity =>
        {
            entity.HasKey(e => e.Idcama);

            entity.ToTable("ubicacioncama");

            entity.Property(e => e.Idcama).HasColumnName("idcama");
            entity.Property(e => e.CodUsuingreso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cod_usuingreso");
            entity.Property(e => e.CodUsumodifica)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cod_usumodifica");
            entity.Property(e => e.Comentario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaModifica)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modifica");
            entity.Property(e => e.Idnrocuarto).HasColumnName("idnrocuarto");
            entity.Property(e => e.Idsubarea).HasColumnName("idsubarea");
            entity.Property(e => e.Nombrecama)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nombrecama");
            entity.Property(e => e.Numerocama).HasColumnName("numerocama");
            entity.Property(e => e.Posicionx).HasColumnName("posicionx");
            entity.Property(e => e.Posiciony).HasColumnName("posiciony");
        });

        modelBuilder.Entity<VigilanciaEpidemiologica>(entity =>
        {
            entity.HasKey(e => e.IdVigilancia).HasName("PK__vigilanc__4D66E88C8ECD13BC");

            entity.ToTable("vigilancia_epidemiologica");

            entity.Property(e => e.IdVigilancia).HasColumnName("ID_vigilancia");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Dx1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dx1");
            entity.Property(e => e.Dx2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dx2");
            entity.Property(e => e.Dx3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dx3");
            entity.Property(e => e.Dx4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dx4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usu).HasName("PK__usuarios__DD778C3E07EC11B9");

            entity.ToTable("usuarios");

            entity.Property(e => e.Usu)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu");
            entity.Property(e => e.Acceso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("acceso");
            entity.Property(e => e.Apematerno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apematerno");
            entity.Property(e => e.Apepaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apepaterno");
            entity.Property(e => e.Clave)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Desdetrabaja).HasColumnName("desdetrabaja");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FecAper)
                .HasColumnType("datetime")
                .HasColumnName("fec_aper");
            entity.Property(e => e.Hastatrabaja).HasColumnName("hastatrabaja");
            entity.Property(e => e.Idsis)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("idsis");
            entity.Property(e => e.Idtrabajador)
                .ValueGeneratedOnAdd()
                .HasColumnName("idtrabajador");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Nrorecibo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("nrorecibo");
            entity.Property(e => e.ServDep)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("serv_dep");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.CodEspec);

            entity.ToTable("especialidad");

            entity.Property(e => e.CodEspec)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_espec");
            entity.Property(e => e.CodDepen)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_depen");
            entity.Property(e => e.CodServi)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cod_servi");
            entity.Property(e => e.Idespegeneral)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idespegeneral");
        });
        modelBuilder.Entity<Subarea>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subarea");

            entity.Property(e => e.CodEspec)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("cod_espec");
            entity.Property(e => e.Idsubarea).HasColumnName("idsubarea");
            entity.Property(e => e.Nombresubarea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombresubarea");
        });

        modelBuilder.Entity<CieSemm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cie_semm");

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descrip)
                .HasMaxLength(243)
                .IsUnicode(false)
                .HasColumnName("descrip");
            entity.Property(e => e.EMax)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("e_max");
            entity.Property(e => e.EMin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("e_min");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Tcie)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tcie");
            entity.Property(e => e.TeMax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("te_max");
            entity.Property(e => e.TeMin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("te_min");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
