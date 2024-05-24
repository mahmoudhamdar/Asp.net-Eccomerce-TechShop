




$(document).ready(function () {
    loadDataTables();
});

function loadDataTables(){

    
    $('#tblData').DataTable({
        ajax:url:'/admin/product/getall'},
            "columns": [
                { data: 'name',"width":"15%" },
                { data: 'position',"width":"15%" },
                { data: 'salary',"width":"15%" },
                { data: 'office',"width":"15%" }
            ]
        })
}


