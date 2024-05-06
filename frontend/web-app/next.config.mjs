/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
        remotePatterns: [
            {
                protocol: 'https',
                hostname: 'images.brickset.com',
                port:''
            }
        ]
    },
    output: 'standalone'
};

export default nextConfig;
