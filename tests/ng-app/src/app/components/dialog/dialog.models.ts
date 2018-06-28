
export interface DialogModel {
    type: DialogType;
    title?: string;
    body?: string;
    buttons?: DialogBtn[];
    defaultResultCode?: string;
}

export enum DialogType {
    Alert,
    Confirm, // YES NO buttons
}

export interface DialogBtn {

    text: string;

    resultCode: ResultCode;

    default: boolean | null;

}

export enum ResultCode {
    Yes = "Yes",
    No = "No",
    OK = "OK"
}