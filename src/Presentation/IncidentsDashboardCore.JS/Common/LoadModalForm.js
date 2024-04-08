import { GetCreateAsync } from '/IDCore.JS/Views/Admin/GetCreateAsync';
import { GetUpdateAsync } from '/IDCore.JS/Views/Admin/GetUpdateAsync';
import { CloseModalEventHandler } from '/IDCore.JS/Common/CloseModalEventHandler';

export const LoadModalForm = (url, title, type) => {

    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById('modalContent').innerHTML = xhr.responseText;
            document.getElementById('modalViewLabel').textContent = title; // Change modal title

            var modalObj = new bootstrap.Modal(document.getElementById('modalView'), {});
            modalObj.show();

            // switch
            switch (type) {
                case 'create':
                    GetCreateAsync(modalObj);
                    break;
                case 'update':
                    GetUpdateAsync(modalObj);
                    break;
                default:
                    break;
            }
            CloseModalEventHandler(modalObj, '#Admin');

        } else {
            console.error('Request failed. Status: ' + xhr.status);
        }
    };
    xhr.send();
}

