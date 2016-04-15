
$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();


    $("#DataExport").click(function () {
        $.ajax({
            type: "post",
            url: "/search/ExportSTATInfo",
            data: getQueryModel(),
            dataType: "json",
            success: function (data) {
                alert("下载完成");
            }
        });
        alert(1);
    });

    $("#DataInport").click(function () {

        var path = "http://pic23.nipic.com/20120817/10703279_193118224000_2.jpg";
        var filename = "testfile";
        $.ajax({
            type: "post",
            url: "/home/DownLoad",
            data: { strName: filename, strPath: path },
            dataType: "json",
            success: function (data) {
                alert("下载完成");
            }
        });
        alert(1);
    });
    function getQueryModel(){
        var obj={
            "criteria.STATId": $("#STATId").val(),
            "criteria.BeginDate": $("#BeginDate").val(),
            "criteria.EndDate": $("#EndDate").val(),
            "criteria.QQ": $("#QQ").val(),
            "criteria.GroupNO": $("#GroupNO").val(),
            "criteria.Tag": $("#Tag").val(),
            "criteria.Status": $("#Status").val(),}
        return obj;
    }
});





var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_statinfo').bootstrapTable({
            url: '/search/GetStatInfoTable',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10],        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: false,
            showColumns: false,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            minimumCountColumns: 5,            //最少允许的列数
            clickToSelect: false,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "ID",                     //每一行的唯一标识，一般为主键列
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                checkbox: true
            }, {
                field: 'STATId',
                title: 'STATId'
            }, {
                field: 'QQ',
                title: 'QQ'
            }, {
                field: 'GroupNo',
                title: 'GroupNo'
            }, {
                field: 'UserName',
                title: 'Id'
            }, {
                field: 'Tag',
                title: 'Tag'
            }, {
                field: 'Tips',
                title: 'Tips'
            }, {
                field: 'Status',
                title: 'Status'
            }, ]
        });
    };



    //得到查询的参数
    oTableInit.queryParams = function (params) {

        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset, //页码
            "criteria.STATId": $("#STATId").val(),
            "criteria.BeginDate": $("#BeginDate").val(),
            "criteria.EndDate": $("#EndDate").val(),
            "criteria.QQ": $("#QQ").val(),
            "criteria.GroupNO": $("#GroupNO").val(),
            "criteria.Tag": $("#Tag").val(),
            "criteria.Status": $("#Status").val(),
        };
        return temp;
    };
    return oTableInit;
};


var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        //$("#btn_add").click(function () {
        //    $("#myModalLabel").text("新增");
        //    $("#myModal").find(".form-control").val("");
        //    $('#myModal').modal()

        //    postdata.DEPARTMENT_ID = "";
        //});

        //$("#btn_edit").click(function () {
        //    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
        //    if (arrselections.length > 1) {
        //        toastr.warning('只能选择一行进行编辑');

        //        return;
        //    }
        //    if (arrselections.length <= 0) {
        //        toastr.warning('请选择有效数据');

        //        return;
        //    }
        //    $("#myModalLabel").text("编辑");
        //    $("#txt_departmentname").val(arrselections[0].DEPARTMENT_NAME);
        //    $("#txt_parentdepartment").val(arrselections[0].PARENT_ID);
        //    $("#txt_departmentlevel").val(arrselections[0].DEPARTMENT_LEVEL);
        //    $("#txt_statu").val(arrselections[0].STATUS);

        //    postdata.DEPARTMENT_ID = arrselections[0].DEPARTMENT_ID;
        //    $('#myModal').modal();
        //});

        $("#btn_delete").click(function () {
            var arrselections = $("#tb_statinfo").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }

            Ewin.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
                if (!e) {
                    return;
                }
                $.ajax({
                    type: "post",
                    url: "/Home/Invalid",
                    data: { "": JSON.stringify(arrselections) },
                    success: function (data, status) {
                        if (status == "success") {
                            toastr.success('所选数据已作废');
                            $("#tb_departments").bootstrapTable('refresh');
                        }
                    },
                    error: function () {
                        toastr.error('Error');
                    },
                    complete: function () {

                    }

                });
            });
        });

        //$("#btn_submit").click(function () {
        //    postdata.DEPARTMENT_NAME = $("#txt_departmentname").val();
        //    postdata.PARENT_ID = $("#txt_parentdepartment").val();
        //    postdata.DEPARTMENT_LEVEL = $("#txt_departmentlevel").val();
        //    postdata.STATUS = $("#txt_statu").val();
        //    $.ajax({
        //        type: "post",
        //        url: "/Home/GetEdit",
        //        data: { "": JSON.stringify(postdata) },
        //        success: function (data, status) {
        //            if (status == "success") {
        //                toastr.success('提交数据成功');
        //                $("#tb_departments").bootstrapTable('refresh');
        //            }
        //        },
        //        error: function () {
        //            toastr.error('Error');
        //        },
        //        complete: function () {

        //        }

        //    });
        //});
        $("#Download_commmit_model").bind("click", function () { window.location.href = '/DownLoad/Commit_STATModel.xlsx'; });

        $("#Query").click(function () {
            $("#tb_statinfo").bootstrapTable('refresh');
        });

        $("#Add").bind("click", function () { window.location.href = '/Commit/Index'; });
        $("#DataExport").bind("click", function () { window.location.href = '/Search/STATInfoExport'; });

    };

    return oInit;
}; 