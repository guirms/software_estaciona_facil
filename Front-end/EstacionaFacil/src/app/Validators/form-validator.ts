import { AbstractControl, FormControl, FormGroup, ValidationErrors } from "@angular/forms";

export class FormValidator {

  static confirmarCampo(campoASerValidado: string) {
    const validator = (formControl: FormControl) => {
      if (campoASerValidado == null) {
        throw new Error('É necessário informar um campo.');
      }

      if (!formControl.root || !(<FormGroup>formControl.root).controls) {
        return null;
      }

      const field = (<FormGroup>formControl.root).get(campoASerValidado);

      if (!field) {
        throw new Error('É necessário informar um campo válido.');
      }

      if (field.value !== formControl.value) {
        return { camposSaoDiferentes : true };
      }

      return null;
    };
    return validator;
  }

}