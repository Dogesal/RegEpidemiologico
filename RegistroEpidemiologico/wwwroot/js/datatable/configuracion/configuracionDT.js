

// tabla de servicios 
new DataTable('#example', {
    ajax: {
        url: '/Servicio/listarServicios',
        dataSrc: '' // Esto indica que el array de datos está en la raíz de la respuesta
    },
    columns: [
        { data: 'nombre' }, // Columna con el nombre
        {
            data: 'idServicio',
            render: function (data) {
                return `
                    <i class="btn btn-primary" title="Editar"  id="editar-${data}" onclick=Editar(${data}) >
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil" viewBox="0 0 16 16">
                            <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325"/>
                        </svg>
                    </i>
                `;
            }
        }
    ]
});



// tabla datos generales

$(document).ready(function () {
    new DataTable('#dataTablaBusquedaRegistro', {
        ajax: {
            url: '/DatosGenerales/registroSocialPaciente', // Endpoint para cargar los datos
            type: 'GET', // Método de la solicitud
            dataSrc: ''  // Los datos están en la raíz del JSON
        },
        columns: [
            { data: 'nombrePaciente' },
            { data: 'servicio' },
            { data: 'idDatosGenerales' },
            { data: 'fechaAplicacion' },
            { data: 'fechaIngreso' },
            { data: 'modalidadIngreso' },
            { data: 'tipoFamilia' },
            { data: 'observacionesFamilia' },
            { data: 'accionesRealizadas' },
            { data: 'diagnosticoSocial' },
            {
                data: 'idDatosGenerales',
                render: function (data) {
                    return `
                    <button class="btn btn-primary" title="Editar" onclick="Editar(${data})">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil" viewBox="0 0 16 16">
                            <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325"/>
                        </svg>
                    </button>
                    <button class="btn btn-warning" title="Ver más información" onclick="MasInfo(${data})">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search-heart" viewBox="0 0 16 16">
                            <path d="M6.5 4.482c1.664-1.673 5.825 1.254 0 5.018-5.825-3.764-1.664-6.69 0-5.018"/>
                            <path d="M13 6.5a6.47 6.47 0 0 1-1.258 3.844q.06.044.115.098l3.85 3.85a1 1 0 0 1-1.414 1.415l-3.85-3.85a1 1 0 0 1-.1-.115h.002A6.5 6.5 0 1 1 13 6.5M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11"/>
                        </svg>
                    </button>
                `;
                }
            }
        ],
        buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
        layout: {
            topStart: 'buttons'
        },
        responsive: true,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json' // Archivo de traducción al español
        },
        paging: true,       // Paginación
        searching: true,    // Búsqueda
        ordering: true,     // Ordenación
        pageLength: 10      // Número de registros por página
    });
});