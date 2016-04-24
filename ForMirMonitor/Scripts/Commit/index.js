$(function () {
    $('.commitform').bootstrapValidator({
        message: 'This value is not valid',
        //feedbackIcons: {
        //    valid: 'glyphicon glyphicon-ok',
        //    invalid: 'glyphicon glyphicon-remove',
        //    validating: 'glyphicon glyphicon-refresh'
        //},
        fields: {
            QQ: {
                message: 'The username is not valid',
                validators: {
                    regexp: {
                        regexp: /[1-9][0-9]{4,}/,
                        message: '*请检查您的QQ号否正确'
                    }
                }
            },
            GroupNo: {
                message: 'The username is not valid',
                validators: {
                    notEmpty: {
                        message: '*请选择您的GroupNo'
                    }
                }
            },
            username: {
                message: 'The username is not valid',
                validators: {
                    notEmpty: {
                        message: '*请输入您的昵称'
                    },
                }
            },
            Tag: {
                validators: {
                    notEmpty: {
                        message: '*请选择您的GroupNo'
                    }
                }
            }
        }
    });

});