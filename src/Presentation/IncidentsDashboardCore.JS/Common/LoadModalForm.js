import { GetCreateAsync } from '/IDCore.JS/Views/Admin/GetCreateAsync';
import { GetUpdateAsync } from '/IDCore.JS/Views/Admin/GetUpdateAsync';
import { GetDeleteAsync } from '/IDCore.JS/Views/Dashboard/GetDeleteAsync';
import { CloseModalEventHandler } from '/IDCore.JS/Common/CloseModalEventHandler';

export const LoadModalForm = (url, title, returnToHash, type) => {

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
                case 'createUser':
                    GetCreateAsync(modalObj);
                    break;
                case 'updateUser':
                    GetUpdateAsync(modalObj);
                    break;
                case 'deleteIncident':
                    GetDeleteAsync(modalObj);
                    break;
                default:
                    break;
            }
            CloseModalEventHandler(modalObj, returnToHash);            

        } else {
            console.error('Request failed. Status: ' + xhr.status);
        }
    };
    xhr.send();
}

