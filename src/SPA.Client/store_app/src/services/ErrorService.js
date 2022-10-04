import { notify } from "@kyvg/vue3-notification";
export default class ErrorService {
  constructor() {
  }

  static onError(error) {

    console.log("🚀 ~ file: ErrorService.js ~ line 7 ~ ErrorService ~ onError ~ error", error)

    const response = error.response;

    if (response && response.status >= 400 && response.status < 405) {
      // You can handle this differently
      ErrorService.sentryLogEngine(error.message);
      return false;
    }

    if (response && response.status === 500) {
      // You can handle this differently
      ErrorService.logRocketLogEngine(error.message);
      return false;
    }

    // Send Error to Log Engine e.g LogRocket
    // ErrorService.logRocketLogEngine(error);
  }

  static onWarn(error) {
    // Send Error to Log Engine e.g LogRocket
    this.logRocketLogEngine(error);
  }

  static onInfo(error) {
    // You can handle this differently
    this.sentryLogEngine(error);
  }

  static onDebug(error) {
    const response = error.response;
    if (response && response.status >= 400 && response.status < 405) {
      // You can handle this differently
      this.sentryLogEngine(error);
      return false;
    }
    // Send Error to Log Engine e.g LogRocket
    this.logRocketLogEngine(error);
  }

  static initHandler() {
    const scope = this;
    window.onerror = (message, url, lineNo, columnNo, error) => {
      console.log(error, "test");
      if (error) {
        scope.onError(error);
        console.log(message, url, lineNo, columnNo, error);
      }
    };
  }

  static displayErrorAlert(message) {
    notify({
      title: "Error",
      text: message,
      type: 'error'
    })
  }

  static displayWarningAlert(message) {
    notify({
      title: "Warning",
      text: message,
      type: 'warning'
    })
  }

  static logRocketLogEngine(error) {
    console.log(error, "LogRocket");
    this.displayErrorAlert(error);
  }

  static sentryLogEngine(error) {
    console.log(error, "Sentry");
  }
}