
$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();

    $("#Query").click(function () {
        oTable.Init();
    });

    $("#download").click(function () {


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
    /* RMA规则信息查询 */
    function QueryPost(pageNo) {

        var queryModel = getQuery();
        if (queryModel == null) {
            alert("查询异常");
            return;
        }
        //var loading = new YTErp.UI.Forms.Loading("#RMARuleList");
        $.ajax(
        {
            url: "/search/GetStatInfoTable",
            type: "get",
            data: queryModel,
            //beforeSend: function () {
            //    AjaxStart();
            //},
            //complete: function () {
            //    AjaxStop();
            //},
            success: function (data) {
                //$("#RMARuleList").html(data.PagersRMARuleHtml);
               // $("#topRMAPageInfo").html(data.PagersTopHtml);
                //$("#bottomRMAPageInfo").html(data.PagersBottomHtml);
                //GetCheckedByHidden();
                //$("#hiddenQueryModel").val($.telerik.toJson(queryModel));

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
            }
        });
    }
    /* RMA规则信息查询结束 */

    //获取查询条件
    function getQuery() {
        var obj = {
            "query.STATId": $("#STATId").val(),
            "query.BeginDate": $("#BeginDate").val(),
            "query.EndDate": $("#EndDate").val(),
            "query.QQ": $("#QQ").val(),
            "query.GroupNO": $("#GroupNO").val(),
            "query.Tag": $("#Tag").val(),
            "query.Status": $("#Status").val(),
        };
        return obj;
    }
    /* 翻页查询信息(TOP) */
    function HeadPageRMARule() {//首页
        if ($("span[name='currentpageRMARule']").eq(0).text() == "1") {
            alert("当前已经是首页");
            return;
        }
        QueryPost(1);
    }
    function PrePageRMARule() {//上一页
        if ($("span[name='currentpageRMARule']").eq(0).text() == "1") {
            alert("当前已经是首页");
            return;
        }
        QueryPost($("span[name='currentpageRMARule']").eq(0).text() * 1 - 1);
    }
    function NextPageRMARule() {//下一页
        if ($("span[name='currentpageRMARule']").eq(0).text() == $("span[name='totalpagesRMARule']").eq(0).text()) {
            alert("当前已经是最后一页");
            return;
        }
        QueryPost($("span[name='currentpageRMARule']").eq(0).text() * 1 + 1);
    }
    function EndPageRMARule() {//末页
        if ($("span[name='currentpageRMARule']").eq(0).text() == $("span[name='totalpagesRMARule']").eq(0).text()) {
            alert("当前已经是最后一页");
            return;
        }
        QueryPost($("span[name='totalpagesRMARule']").eq(0).text() * 1);
    }
    function PageGORMARule() {//跳转
        if ($("input[name='gotopageRMARule']").val() == "") return;
        if ($("input[name='gotopageRMARule']").val() * 1 >= $("span[name='totalpagesRMARule']").eq(0).text() * 1) {
            QueryPost($("span[name='totalpagesRMARule']").eq(0).text() * 1);
        }
        else if ($("input[name='gotopageRMARule']").val() * 1 == $("span[name='currentpageRMARule']").eq(0).text() * 1) {
            return;
        }
        else {
            QueryPost($("input[name='gotopageRMARule']").val());
        }
    }
    /* 翻页.RMA规则查询信息结束 */

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
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: false,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            //minimumCountColumns: 5,            //最少允许的列数
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
        function getCriteria() {
            var obj = {
                "query.STATId": $("#STATId").val(),
                "query.BeginDate": $("#BeginDate").val(),
                "query.EndDate": $("#EndDate").val(),
                "query.QQ": $("#QQ").val(),
                "query.GroupNO": $("#GroupNO").val(),
                "query.Tag": $("#Tag").val(),
                "query.Status": $("#Status").val(),
            };
            return obj;
        }
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset, //页码
            criteria: getCriteria(), //查询条件        
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

        //$("#btn_delete").click(function () {
        //    var arrselections = $("#tb_departments").bootstrapTable('getSelections');
        //    if (arrselections.length <= 0) {
        //        toastr.warning('请选择有效数据');
        //        return;
        //    }

        //    Ewin.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
        //        if (!e) {
        //            return;
        //        }
        //        $.ajax({
        //            type: "post",
        //            url: "/Home/Delete",
        //            data: { "": JSON.stringify(arrselections) },
        //            success: function (data, status) {
        //                if (status == "success") {
        //                    toastr.success('提交数据成功');
        //                    $("#tb_departments").bootstrapTable('refresh');
        //                }
        //            },
        //            error: function () {
        //                toastr.error('Error');
        //            },
        //            complete: function () {

        //            }

        //        });
        //    });
        //});

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

        //$("#btn_query").click(function () {
        //    $("#tb_departments").bootstrapTable('refresh');
        //});
    };

    return oInit;
}; 