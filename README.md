# Electrics-Eagles-Log-Parser
[![SWUbanner](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/banner2-direct.svg)](https://vshymanskyy.github.io/StandWithUkraine)

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
npm install --global yarn
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


https://user-images.githubusercontent.com/20460747/151638596-9c542b81-31a7-4d24-870e-f6d066611a76.mp4
