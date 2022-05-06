import type { App, Plugin } from 'vue';

export const withInstall = <T>(component: T, alias?: string) => {
  const componentAny = component as any;
  componentAny.install = (app: App) => {
    app.component(componentAny.name || componentAny.displayName, component);

    if (alias) {
      app.config.globalProperties[alias] = component;
    }
  };

  return component as T & Plugin;
};
