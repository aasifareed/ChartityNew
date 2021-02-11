/// <reference path="jsColumns.js" />
function GetCol(tbl) {
    switch (tbl) {

        case "SliderList":
            return [
                { title: "Id", data: "Id", "visible": false },

                {
                    title: "Slider",
                    data: "ImagePath",
                    render: function (data, type, row) {
                        return '<img src="' + data + '" class="icons" style="width: 300px;max-height:80px;" />';
                    },
                    className: "text-center"
                },
                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '&nbsp;<button class="btn btn-danger btn-sm icon-btn ml-2 mb-2m" onclick="OnGridDelete(this)" title="Delete Record"> <i class="fa fa-trash"></i></button>';
                        return btnview;
                    },
                    width: "200px",
                    sortable: false,
                    className: "text-center"
                }
            ];

        case "BlogList":
            return [
                { title: "Id", data: "Id", "visible": false },

                {
                    title: "Image",
                    data: "ImagePath",
                    render: function (data, type, row) {
                        return '<img src="' + data + '" class="icons" style="width: 100px;max-height:100px;" />';
                    },
                    className: "text-center"
                },

                  { title: "Title", data: "TitleEn" },
                  { title: "Date", data: "Date", render: function (value) { return parseJsonDateforRemarks(value); } },

                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button class="btn btn-warning btn-large btn-sm"  onclick="OnGridEdit(this)" title="Edit;"> <i class="fa fa-edit"></i></button>';
                        btnview = btnview + '&nbsp;<button class="btn btn-danger btn-sm icon-btn ml-2 mb-2m" onclick="OnGridDelete(this)" title="Delete Record"> <i class="fa fa-trash"></i></button>';
                        return btnview;
                    },
                    width: "200px",
                    sortable: false,
                    className: "text-center"
                }
            ];
        case "NewsList":
            return [
                { title: "Id", data: "Id", "visible": false },

                {
                    title: "Image",
                    data: "ImagePath",
                    render: function (data, type, row) {
                        return '<img src="' + data + '" class="icons" style="width: 100px;max-height:100px;" />';
                    },
                    className: "text-center"
                },

                  { title: "Title", data: "TitleEn" },
                  { title: "Date", data: "CreatedOn", render: function (value) { return parseJsonDateforRemarks(value); } },

                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '<button class="btn btn-warning btn-large btn-sm"  onclick="OnGridEdit(this)" title="Edit;"> <i class="fa fa-edit"></i></button>';
                        btnview = btnview + '&nbsp;<button class="btn btn-danger btn-sm icon-btn ml-2 mb-2m" onclick="OnGridDelete(this)" title="Delete Record"> <i class="fa fa-trash"></i></button>';
                        return btnview;
                    },
                    width: "200px",
                    sortable: false,
                    className: "text-center"
                }
            ];
        case "ContactUsList":
            return [
                { title: "Id", data: "Id", "visible": false },
                { title: "Name", data: "Name" },
                { title: "Email", data: "Email" },
                { title: "Phone", data: "PhoneNo" },
                { title: "Message", data: "Message"},
                { title: "Date", data: "CreatedOn", render: function (value) { return parseJsonDateforRemarks(value); } },

                {
                    title: "Action",
                    data: null,
                    render: function (data, type, row) {
                        btnview = "";
                        btnview = '&nbsp;<button class="btn btn-danger btn-sm icon-btn ml-2 mb-2m" onclick="OnGridDelete(this)" title="Delete Record"> <i class="fa fa-trash"></i></button>';
                        return btnview;
                    },
                    width: "200px",
                    sortable: false,
                    className: "text-center"
                }
            ];
        default:
            return [];

    }
}