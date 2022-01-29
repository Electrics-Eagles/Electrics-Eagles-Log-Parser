# Electrics-Eagles-Log-Parser


Run :
on Manjaro :
```

sudo pacman -Syy && sudo pacman -S  webkit2gtk \
    base-devel \
    curl \
    wget \
    openssl \
    appmenu-gtk-module \
    gtk3 \
    libappindicator-gtk3 \
    patchelf \
    librsvg \
    libvips
```
 Then install nvm
```
 curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.35.2/install.sh | bash
```
 Install last node using nvm 
 ```
 nvm install node --latest-npm
nvm use node
```
Then install yarn : 
```
npm install --global yar
```

Then install Rust 
```
curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh
```

Then move to folder and add dep : 
```
yarn add -D @tauri-apps/cli
```
Then install api via 
```
yarn add @tauri-apps/api
```

and finally run 
```
yarn tauri dev 
```

