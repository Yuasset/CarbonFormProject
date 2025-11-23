const SurveyManager = {
    saveData: function (key, data) {
        sessionStorage.setItem(key, JSON.stringify(data));
    },

    getData: function (key) {
        const data = sessionStorage.getItem(key);
        return data ? JSON.parse(data) : null;
    },

    clearAllData: function () {
        sessionStorage.clear();
    },

    loadForm: function (key) {
        const data = this.getData(key);
        if (data) {
            $.each(data, function (name, val) {
                var $el = $('[name="' + name + '"]');
                var type = $el.attr('type');

                if ($el.length > 0) {
                    if (type === 'checkbox') {
                        $el.prop('checked', val);
                    } else if (type === 'radio') {
                        $el.filter('[value="' + val + '"]').prop('checked', true);
                    } else {
                        $el.val(val);
                    }
                }
            });
        }
    },

    serializeForm: function (formId) {
        var o = {};
        var $form = $(formId);
        var a = $form.serializeArray();

        $form.find('input[type=checkbox]:not(:checked)').each(function () {
            a.push({ name: this.name, value: false });
        });

        $.each(a, function () {
            let name = this.name;
            let value = this.value;

            let $input = $form.find('[name="' + name + '"]');
            let type = $input.attr('type');

            if (type === 'number') {
                if (value === "") {
                    value = 0;
                } else {
                    value = Number(value);
                }
            }

            else if (!isNaN(value) && value !== "" && type !== 'date' && type !== 'email' && type !== 'checkbox' && type !== 'radio') {
                value = Number(value);
            }

            if (value === "true") value = true;
            if (value === "false") value = false;

            if (o[name]) {
                if (!o[name].push) {
                    o[name] = [o[name]];
                }
                o[name].push(value);
            } else {
                o[name] = value;
            }
        });
        return o;
    },

    validateAndNext: function (formId, storageKey, endpointUrl, nextUrl) {
        const formData = this.serializeForm(formId);

        $.ajax({
            url: endpointUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function () {
                SurveyManager.saveData(storageKey, formData);
                window.location.href = nextUrl;
            },
            error: function (xhr) {
                if (xhr.responseJSON) {
                    let msg = "";
                    xhr.responseJSON.forEach(e => msg += "- " + e + "\n");
                    alert("Lütfen aşağıdaki hataları düzeltin:\n" + msg);
                } else {
                    alert("Bir hata oluştu.");
                }
            }
        });
    },

    submitAll: function () {
        const fullData = {
            UserInfo: this.getData('step1_data'),
            Transportation: this.getData('step2_data'),
            HomeEnergy: this.getData('step3_data'),
            Consumption: this.getData('step4_data')
        };

        $.ajax({
            url: '/Home/SubmitSurvey',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(fullData),
            success: function (res) {
                alert(res.message);
                SurveyManager.clearAllData();
                window.location.href = '/Home/Index';
            },
            error: function () {
                alert("Kaydedilirken bir hata oluştu.");
            }
        });
    }
};