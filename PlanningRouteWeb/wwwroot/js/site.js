//function exportExcel() {
//    const timeElapsed = Date.now();
//    const today = new Date(timeElapsed);
//    const table = document.getElementById('table-export-excel');
//    const wb = XLSX.utils.table_to_book(table, { sheet: 'sheet-1' });
//    XLSX.writeFile(wb, `Planning-${today.toISOString()}.xlsx`, { cellStyles: true });
//};

//function getSystems() {
//    var sec = JSON.parse(sessionStorage.getItem("permission"))
//    return sec.system.OrganizationList.map(x => x.ORGANIZATION_CODE)
//}

//function getSystems2() {
//    var sec = JSON.parse(sessionStorage.getItem("permission"))
//    return { code: sec.system.OrganizationList[0].ORGANIZATION_CODE, name: sec.system.OrganizationList[0].ORGANIZATION_NAME }
//}

//function tooltipTrigger() {
//    let elToolTip = [].slice.call(
//        document.querySelectorAll('[data-bs-toggle="tooltip"]')
//    );

//    elToolTip.forEach(function (tooltipTriggerEl) {
//        new bootstrap.Tooltip(tooltipTriggerEl);
//    });
//}

//function getValueDatepicker() {
//    let date = dayjs($('#dateStart').datepicker('getDate'))

//    return { month: date.format('MM'), year: date.format('YYYY') }
//}

//function getDatepicker() {
//    let start = dayjs($('#dateStart').datepicker('getDate')).format('YYYY-MM-DD');
//    let end = dayjs($('#dateEnd').datepicker('getDate')).format('YYYY-MM-DD');
//    return [start, end];
//}



//function toastTrigger(options) {
//    let opts = {
//        autohide: options.autohide,
//        delay: options.delay,
//    };

//    opts.autohide = options.action === "error" ? false : true;

//    toastInit(opts);

//    let toastContainer = document.getElementById("toastContainer");
//    toastContainer.style.zIndex = 10;

//    let toastEl = document.getElementById("toastAlert");
//    if (options.action === "error") {
//        toastEl.classList.add("bg-danger");
//    } else if (options.action === "info") {
//        toastEl.classList.add("bg-primary");
//    } else if (options.action === "success") {
//        toastEl.classList.add("bg-success");
//    }

//    let toastMsg = document.getElementById("toastMsg");
//    toastMsg.innerHTML = options.messang;

//    let toast = bootstrap.Toast.getOrCreateInstance(toastEl);
//    toast.show();
//}



//function setDateTimeOnParameter(start, end) {
//    $('#dateStart').datepicker("setDate", new Date(start))
//    $('#dateEnd').datepicker("setDate", new Date(end))
//}
function setQueryParams(key, value) {
    var queryParams = new URLSearchParams(window.location.search);
    queryParams.set(key, dayjs(value).format('YYYY-MM-DD'));
    history.replaceState(null, null, window.location.pathname + "?" + queryParams.toString());
}
function toastInit(opt) {
    let toastElList = [].slice.call(document.querySelectorAll(".toast"));
    let toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl, opt);
    });
}
export class InitailJS {
    static tooltipTrigger() {
        let elToolTip = [].slice.call(
            document.querySelectorAll('[data-bs-toggle="tooltip"]')
        );

        elToolTip.forEach(function (tooltipTriggerEl) {
            new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }
    static initailDatepicker(start, end) {
        document.getElementById("routeName").innerHTML = "";
        let option = {
            language: 'th',
            format: 'dd/mm/yyyy',
            autoclose: true,
            weekStart: 1,
            calendarWeeks: true,
            todayHighlight: true,
        }

        $('#dateStart')
            .datepicker(option)
            .datepicker("setDate",  new Date())
            .on('changeDate', function () {
                var temp = $(this).datepicker('getDate');
                var d = new Date(temp);
                d.setDate(d.getDate());
                setQueryParams("Start", temp);
                $('#dateEnd').datepicker("setStartDate", d);
            });

        $('#dateEnd')
            .datepicker(option)
            .datepicker("setDate",  new Date())
            .on('changeDate', function () {
                var temp = $(this).datepicker('getDate');
                setQueryParams("End", temp);
            });

        if (start && end) {
            $('#dateStart').datepicker("setDate", new Date(start))
            $('#dateEnd').datepicker("setDate", new Date(end))
        }
    }
}
export class JsFunction {
    static getSystems() {
        var sec = JSON.parse(sessionStorage.getItem("permission"))
        return sec.system.OrganizationList.map(x => x.ORGANIZATION_CODE)
    }
    static toastTrigger(options) {
        let opts = {
            autohide: options.autohide,
            delay: options.delay,
        };

        opts.autohide = options.action === "error" ? false : true;

        toastInit(opts);

        let toastContainer = document.getElementById("toastContainer");
        toastContainer.style.zIndex = 10;

        let toastEl = document.getElementById("toastAlert");
        if (options.action === "error") {
            toastEl.classList.add("bg-danger");
        } else if (options.action === "info") {
            toastEl.classList.add("bg-primary");
        } else if (options.action === "success") {
            toastEl.classList.add("bg-success");
        }

        let toastMsg = document.getElementById("toastMsg");
        toastMsg.innerHTML = options.messang;

        let toast = bootstrap.Toast.getOrCreateInstance(toastEl);
        toast.show();
    }
    static exportExcel() {
        const timeElapsed = Date.now();
        const today = new Date(timeElapsed);
        const table = document.getElementById('table-export-excel');
        const wb = XLSX.utils.table_to_book(table, { sheet: 'sheet-1' });
        XLSX.writeFile(wb, `Planning-${today.toISOString()}.xlsx`, { cellStyles: true });
    }
    static getDatepicker() {
        let start = dayjs($('#dateStart').datepicker('getDate')).format('YYYY-MM-DD');
        let end = dayjs($('#dateEnd').datepicker('getDate')).format('YYYY-MM-DD');
        return [start, end];
    }
    static getValueDatepicker() {
        let date = dayjs($('#dateStart').datepicker('getDate'))

        return { month: date.format('MM'), year: date.format('YYYY') }
    }
 
}
window.JsFunction = JsFunction;
window.InitailJS = InitailJS;