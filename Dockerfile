from mcr.microsoft.com/dotnet/sdk 
ARG site_version=
# Do "--build-arg site_version=YES" to build the alternate version of the container for the alternate site
RUN echo $site_version

# Install .NET Core SDK
RUN dotnet_sdk_version=3.1.404 \
    && curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Sdk/$dotnet_sdk_version/dotnet-sdk-$dotnet_sdk_version-linux-x64.tar.gz \
    && dotnet_sha512='94d8eca3b4e2e6c36135794330ab196c621aee8392c2545a19a991222e804027f300d8efd152e9e4893c4c610d6be8eef195e30e6f6675285755df1ea49d3605' \
    && echo "$dotnet_sha512 dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet3 \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && ln -s /usr/share/dotnet3/dotnet /usr/bin/dotnet3 \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

COPY . .
WORKDIR clients
RUN dotnet restore
RUN dotnet build
WORKDIR src/JsOidc
RUN ./select_version.sh
CMD ["dotnet", "run", "JsOidc.csproj"]
